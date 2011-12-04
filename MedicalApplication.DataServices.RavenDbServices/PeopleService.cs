using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedicalApplication.DataServices.Models;
using MedicalApplication.DataServices.Services;
using Raven.Client.Document;
using Raven.Abstractions.Data;

namespace MedicalApplication.DataServices.Services.RavenDb
{
    public class PeopleService : IPeopleService
    {
        private DocumentStore dbStore {get;set;}

        public PeopleService()
        {
            dbStore = new DocumentStore { ConnectionStringName="MedicalDb" }; 
            dbStore.Initialize();
        }

        public void AddPerson(Person person)
        {            
            using (var session = dbStore.OpenSession())
            {
                session.Store(person);
                session.SaveChanges();
            }
        }

        public List<Person> GetAllPeopleByType(PersonTypeEnum type)
        {
            using (var session = dbStore.OpenSession())
            {
                var people = session.Query<Person>()
                    .Where(p => p.PersonType == type)
                    .ToList();

                return people;                        
            }
        }

        public List<Person> GetAllPatients()
        {
            return GetAllPeopleByType(PersonTypeEnum.Patient);
        }

        public List<Person> GetAllSurgeons()
        {
            return GetAllPeopleByType(PersonTypeEnum.Surgeon);
        }

        public List<Person> GetAllAdmins()
        {
            return GetAllPeopleByType(PersonTypeEnum.Admin);
        }

        public Person GetPersonById(string id)
        {
            using (var session = dbStore.OpenSession())
            {
                var person = session.Load<Person>(id);
                return person;
            }
        }

        public List<Person> SearchByNameAndType(string name, PersonTypeEnum personType)
        {
            using (var session = dbStore.OpenSession())
            {
                var people = session.Advanced.LuceneQuery<Person>()
                    .Where(string.Format("PersonType:{0} && (FirstName:*{1}* || MiddleName:*{1}* || LastName:*{1}*)",
                            personType,name.ToLower()))
                    .Take(100)
                    .ToList();

                return people;
            }
        }

        public void DeletePerson(Person person)
        {
            using (var session = dbStore.OpenSession())
            {
                session.Delete<Person>(person);
                session.SaveChanges();
            }
        }

        public void DeleteAllPeople()
        {
            dbStore.DatabaseCommands.DeleteByIndex("//Raven/DocumentsByEntityName", new IndexQuery()
            {
                Query = "Tag:People"
            }, allowStale: true);
        }

        public void UpdatePerson(Person person)
        {
            using (var session = dbStore.OpenSession())
            {
                var dbPerson = session.Load<Person>(person.Id);
                dbPerson.PopulateFromPerson(person);
                session.SaveChanges();
            }
        }
    }
}