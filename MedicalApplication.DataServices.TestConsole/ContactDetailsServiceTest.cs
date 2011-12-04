using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalApplication.DataServices.Models;
using MedicalApplication.DataServices.Services;
using MedicalApplication.DataServices.Services.RavenDb;

namespace MedicalApplication.DataServices.TestConsole
{
    public class ContactDetailsServiceTest
    {
        IPeopleService peopleService;
        IContactDetailsService contactDetailsService;

        public ContactDetailsServiceTest()
        {
            peopleService = new PeopleService();
            contactDetailsService = new ContactDetailsService();
        }

        public void AddAddressToPerson()
        {
            Console.WriteLine("Testing addition of new address to person");

            //This is the person we have retrieved (i.e. by search)
            var person = peopleService
                .SearchByNameAndType("Roberto", PersonTypeEnum.Patient)
                .First();

            var personId = person.Id; //for later use

            Console.WriteLine("Person being tested: {0} {1} {2}",person.FirstName, person.MiddleName, person.LastName);

            Console.WriteLine("Existing addresses for this person:");
            IEnumerable<Address> addresses = contactDetailsService.GetAddressesByPerson(personId);
            foreach (Address a in addresses)
            {
                Console.WriteLine("----------------------------");
                DisplayAddress(a);
            }

            Console.WriteLine("Adding new address for this person:");
            //now we crate a new address (by grabbing details from Add address screen)
            var address = new Address
            {
                AddressLine1 = "Via Caserma Lucania, 48",
                Town = "Potenza",
                StateCounty = "PZ",
                Country = "Italy",
                PostCode = "85100",
                AddressType = AddressTypeEnum.Other
            };

            //now we persist the new address and link it to the correct person
            contactDetailsService.AddAddressToPerson(address, person);
            Console.WriteLine("New address for this person has been addres");

            //Now we reshow all the addresses for this person
            //after re-retrieving the person from the database
            addresses = contactDetailsService.GetAddressesByPerson(personId);

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Updated addresses for this person:");
            foreach (Address a in addresses)
            {
                Console.WriteLine("----------------------------");
                DisplayAddress(a);
            }
        }

        public void AddEmailAddressToPerson()
        {
            Console.WriteLine("Testing addition of new address to person");

            var peopleService = new PeopleService();
            var contactDetailsService = new ContactDetailsService();

            //This is the person we have retrieved (i.e. by search)
            var person = peopleService
                .SearchByNameAndType("Roberto", PersonTypeEnum.Patient)
                .First();

            var personId = person.Id; //for later use

            Console.WriteLine("Person being tested: {0} {1} {2}", person.FirstName, person.MiddleName, person.LastName);

            Console.WriteLine("Existing addresses for this person:");
            IEnumerable<EmailAddress> emailAddresses = contactDetailsService.GetEmailAddressesByPerson(personId);
            foreach (EmailAddress a in emailAddresses)
            {
                Console.WriteLine("----------------------------");
                DisplayEmailAddress(a);
            }


            Console.WriteLine("Adding new email address for this person:");
            //now we crate a new address (by grabbing details from Add address screen)
            var email = new EmailAddress
            {
                Address = "roberto.infante@hotmail.com",
                EmailAddressType =  EmailAddressTypeEnum.Other
            };


            //now we persist the new email address and link it to the correct person
            contactDetailsService.AddEmailAddressToPerson(email, person);
            Console.WriteLine("New email address has been added");

            //Now we reshow all the email addresses for this person
            //after re-retrieving the person from the database
            emailAddresses = contactDetailsService.GetEmailAddressesByPerson(personId);

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Updated email addresses for this person:");
            foreach (EmailAddress a in emailAddresses)
            {
                Console.WriteLine("----------------------------");
                DisplayEmailAddress(a);
            }
        }

        public void UpdateAddress()
        {
            Console.WriteLine("Testing addition of new address to person");

            var peopleService = new PeopleService();
            var contactDetailsService = new ContactDetailsService();

            //This is the person we have retrieved (i.e. by search)
            var person = peopleService
                .SearchByNameAndType("Roberto", PersonTypeEnum.Patient)
                .First();

            var personId = person.Id; //for later use

            Console.WriteLine("Person being tested: {0} {1} {2}", person.FirstName, person.MiddleName, person.LastName);

            Console.WriteLine("Existing addresses for this person:");
            IEnumerable<Address> addresses = contactDetailsService.GetAddressesByPerson(personId);
            foreach (Address a in addresses)
            {
                Console.WriteLine("----------------------------");
                DisplayAddress(a);
            }

            Console.WriteLine("Editing of first address: we change country name to New Zealand");
            //we grab the first address//on the UI it is easier because we have a direct reference
            //to the address being edited
            Address addressToEdit = addresses.ToList().First();

            //alternatively, if we have only the addressId, we can get the Address in this way: 
            //Address addressToEdit = contactDetailsService.GetAddressById(addressId);
/*
            //we change the country name:
            addressToEdit.Country = "New Zealand";

            //we update the address
            contactDetailsService.UpdateAddress(addressToEdit);

            //Now we reshow all the addresses for this person
            //after re-retrieving the person from the database
            addresses = contactDetailsService.GetAddressesByPerson(personId);
*/
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Updated addresses for this person:");
            foreach (Address a in addresses)
            {
                Console.WriteLine("----------------------------");
                DisplayAddress(a);
            }
 
        }

        private void DisplayAddress(Address address)
        {
            Console.WriteLine(string.Format("{0}", address.AddressLine1));
            if (!string.IsNullOrEmpty(address.AddressLine2))
                Console.WriteLine(string.Format("{0}", address.AddressLine2));
            if (!string.IsNullOrEmpty(address.AddressLine3))
                Console.WriteLine(string.Format("{0}", address.AddressLine3));
            if (!string.IsNullOrEmpty(address.Town))
                Console.WriteLine(string.Format("{0}", address.Town));
            if (!string.IsNullOrEmpty(address.StateCounty))
                Console.WriteLine(string.Format("{0}", address.StateCounty));
            if (!string.IsNullOrEmpty(address.PostCode))
                Console.WriteLine(string.Format("{0}", address.PostCode));
            if (!string.IsNullOrEmpty(address.Country))
                Console.WriteLine(string.Format("{0}", address.Country));
            Console.WriteLine(string.Format("Address type: {0}", ((AddressTypeEnum) address.AddressType)).ToString());
        }

        private void DisplayEmailAddress(EmailAddress email)
        {
            if (!string.IsNullOrEmpty(email.Address))
                Console.WriteLine(string.Format("{0}", email.Address));
            Console.WriteLine(string.Format("Email Address type: {0}", ((EmailAddressTypeEnum)email.EmailAddressType)).ToString());
        }
    }
}
