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
    public class ContactDetailsService : IContactDetailsService
    {
        private DocumentStore dbStore { get; set; }

        public ContactDetailsService()
        {
            dbStore = new DocumentStore { ConnectionStringName = "MedicalDb" }; 
            dbStore.Initialize();
        }

        public void AddAddressToPerson(Address address, string personId)
        {
            using (var session = dbStore.OpenSession())
            {
                Person dbPerson = session.Load<Person>(personId);
                dbPerson.Addresses.Add(address);

                session.SaveChanges();
            }
        }

        public void AddAddressToPerson(Address address, Person person)
        {
            var personId = person.Id;

            AddAddressToPerson(address, personId);
        }

        public IEnumerable<Address> GetAddressesByPerson(string personId)
        {
            IEnumerable<Address> addresses = null;
            using (var session = dbStore.OpenSession())
            {
                addresses = session.Load<Person>(personId).Addresses;
            }
            return addresses;
        }

        /*
        public Address GetAddressById(int addressId)
        {
            Address address = null;
            using (var db = new MedicalApplicationEntities())
            {
                try
                {
                    address = db.Addresses.Find(addressId);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return address;
        }
        */

        public void AddEmailAddressToPerson(EmailAddress address, string personId)
        {
            using (var session = dbStore.OpenSession())
            {
                Person dbPerson = session.Load<Person>(personId);
                dbPerson.EmailAddresses.Add(address);

                session.SaveChanges();
            }
        }

        public void AddEmailAddressToPerson(EmailAddress address, Person person)
        {
            var personId = person.Id;

            AddEmailAddressToPerson(address, personId);
        }

        public IEnumerable<EmailAddress> GetEmailAddressesByPerson(string personId)
        {
            IEnumerable<EmailAddress> addresses = null;
            using (var session = dbStore.OpenSession())
            {
                addresses = session.Load<Person>(personId).EmailAddresses;
            }
            return addresses;
        }
    }
}
