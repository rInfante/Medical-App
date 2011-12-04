using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedicalApplication.DataServices.Models;

namespace MedicalApplication.DataServices.Services
{
    public interface IPeopleService
    {
        void AddPerson(Person person);
        List<Person> GetAllPeopleByType(PersonTypeEnum type);
        List<Person> GetAllPatients();
        List<Person> GetAllSurgeons();
        List<Person> GetAllAdmins();
        Person GetPersonById(string id);
        List<Person> SearchByNameAndType(string name, PersonTypeEnum personType);
        void DeletePerson(Person person);
        void DeleteAllPeople();
        void UpdatePerson(Person person);
    }
}
