using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedicalApplication.DataServices.Models;
using MedicalApplication.DataServices.Services;
using MedicalApplication.DataServices.Services.RavenDb;

namespace MedicalApplication.DataServices.TestConsole
{
    public class PeopleServiceTest
    {
        IPeopleService peopleService;

        public PeopleServiceTest()
        {
            peopleService = new PeopleService();
        }

        public void DeleteAllPeople()
        {
            Console.WriteLine("DELETING ALL PEOPLE!");
            peopleService.DeleteAllPeople();
        }

        /// <summary>
        /// This simulates how patient data is grabbed from the Add Patient screen
        /// and the patient is then persisted
        /// </summary>
        public void AddNewPatient_FullInformation()
        {
            Console.WriteLine("Testing insertion of a patient (Roberto Infante)");
            //grab addresses from address section of UI
            //We can add one or more addresses
            Console.WriteLine("Grabbing Addresses");
            var addresses = new List<Address>
            {                
                //we grab the address type value from the SelectedValue of the AddressType dropdown
                //which is populated from: AddressService.GetAllAddressTypes()
                
                new Address {AddressLine1="Flat 17 - Meridian Court", AddressLine2="3, East Lane",
                    Town="Bermondsey", StateCounty="Greater London", PostCode="SE16 4UF", Country="United Kingdom",
                    AddressType = AddressTypeEnum.Home},
                new Address {AddressLine1="Juan de Garai, 11", AddressLine2="4-D", Town="Barakaldo", StateCounty="Bizkaia",
                    PostCode="48001", Country="Spain", AddressType= AddressTypeEnum.SecondHome}
            };

            Console.WriteLine("Grabbing email addresses");
            var emailAddresses = new List<EmailAddress>
            {
                //we grab the email address type value from the SelectedValue of the EmailType dropdown
                //which is populated from: AddressService.GetAllEmailAddressTypes()

                new EmailAddress{Address="roberto.g.infante@gmail.com", EmailAddressType= EmailAddressTypeEnum.Private},
                new EmailAddress{Address="roberto.infante@sgcib.com", EmailAddressType= EmailAddressTypeEnum.Work}
            };

            Console.WriteLine("Grabbing phone numbers");
            var phoneNumbers = new List<PhoneNumber>
            {
                //we grab the email address type value from the SelectedValue of the PhoneNumber dropdown
                //which is populated from: AddressService.GetAllPhoneNumberTypes()

                new PhoneNumber{Number="00447780911481", PhoneNumberType= PhoneNumberTypeEnum.PrivateMobile},
                new PhoneNumber{Number="00442072316748", PhoneNumberType= PhoneNumberTypeEnum.Home}
            };

            Console.WriteLine("Grab patient details");
            var patient1 = new Person
            {
                Title = "Mr",
                FirstName = "Roberto",
                MiddleName = "Giuseppe",
                LastName = "Infante",
                Sex = "M",
                DateOfBirth = new DateTime(1972, 6, 1),
                Employer = "DevQF Limited",
                Qualifications = "MSc",
                Occupation = "IT consultant",
                Salutation = "Dear",//what does Salutation mean?
                PersonType = PersonTypeEnum.Patient,//this is hardcoded for patients//MUST make sure it is set like this                
                Addresses = addresses,
                EmailAddresses = emailAddresses,
                PhoneNumbers = phoneNumbers
            };

            //Persist patient
            Console.WriteLine("Persisting patient...");
            try
            {                
                peopleService.AddPerson(patient1);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }
        }

        public void PrePopulateVariousPatients()
        {
            Person person;

            Console.WriteLine("Prepopulating various patients");

            Console.WriteLine("Populating: Brad Pitt");
            person = new Person
            {
                Title = "Mr",
                FirstName = "Brad",
                MiddleName = "",
                LastName = "Pitt",
                Sex = "M",
                DateOfBirth = new DateTime(1969, 4, 3),
                Employer = "",
                Qualifications = "",
                Occupation = "Actor",
                Salutation = "Dear",
                PersonType = PersonTypeEnum.Patient,
                Addresses = new List<Address>{new Address{AddressLine1="101 Long Drive",AddressLine2="Beverly Hills", Town="Los Angeles",
                   PostCode="90001", StateCounty="California", Country="United States",  AddressType=AddressTypeEnum.Home}},
                EmailAddresses = new List<EmailAddress> { new EmailAddress { Address = "brad.pitt@hotmail.com", EmailAddressType = EmailAddressTypeEnum.Private } },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "001 221 55589898", PhoneNumberType = PhoneNumberTypeEnum.Home } }
            };

            Console.WriteLine("Persisting patient...");
            try
            {
                peopleService.AddPerson(person);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }

            Console.WriteLine("Populating: Cordelia Barnes");
            person = new Person
            {
                Title = "Ms",
                FirstName = "Cordelia",
                MiddleName = "",
                LastName = "Barnes",
                Sex = "F",
                DateOfBirth = new DateTime(1969, 4, 3),
                Employer = "Tesco",
                Qualifications = "BSc",
                Occupation = "Cashier",
                Salutation = "Dear",
                PersonType = PersonTypeEnum.Patient,
                Addresses = new List<Address>{new Address{AddressLine1="24 Bazeley Ho Library St",AddressLine2="", Town="London",
                   PostCode="SE1 0RN", StateCounty="Greater London", Country="United Kingdom",  AddressType=AddressTypeEnum.Home}},
                EmailAddresses = new List<EmailAddress> { new EmailAddress { Address = "cordelia.barnes@hotmail.com", EmailAddressType = EmailAddressTypeEnum.Private } },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "0044 207 928 0051", PhoneNumberType = PhoneNumberTypeEnum.Home },
                new PhoneNumber{Number="0044 0778 0946898", PhoneNumberType= PhoneNumberTypeEnum.PrivateMobile}}
            };

            Console.WriteLine("Persisting patient...");
            try
            {
                peopleService.AddPerson(person);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }

            Console.WriteLine("Populating: Adam Aldridge");
            person = new Person
            {
                Title = "Mr",
                FirstName = "Adam",
                MiddleName = "",
                LastName = "Aldridge",
                Sex = "M",
                DateOfBirth = new DateTime(1969, 4, 3),
                Employer = "BT",
                //Qualifications = "",
                Occupation = "telephone engineer",
                Salutation = "Dear",
                PersonType = PersonTypeEnum.Patient,
                Addresses = new List<Address>{new Address{AddressLine1="50 Granville Ct De Beauvoir Est",AddressLine2="", Town="London",
                   PostCode="N1 5SP", StateCounty="Greater London", Country="United Kingdom",  AddressType=AddressTypeEnum.Home}},
                EmailAddresses = new List<EmailAddress> { new EmailAddress { Address = "adam.aldridge@bt.com", EmailAddressType = EmailAddressTypeEnum.Work } },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "0044 203 076 1054", PhoneNumberType = PhoneNumberTypeEnum.Home } }
            };

            Console.WriteLine("Persisting patient...");
            try
            {
                peopleService.AddPerson(person);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }

            Console.WriteLine("Populating: Jack Smith");
            person = new Person
            {
                Title = "Mr",
                FirstName = "Jack",
                MiddleName = "",
                LastName = "Smith",
                Sex = "M",
                DateOfBirth = new DateTime(1969, 4, 3),
                Employer = "Goldman Sachs",
                //Qualifications = "",
                Occupation = "Software developer",
                Salutation = "Dear",
                PersonType = PersonTypeEnum.Patient,
                Addresses = new List<Address>{new Address{AddressLine1="13 Ashley Clo",AddressLine2="Killamarsh", Town="Sheffield",
                   PostCode="S21 1AA", StateCounty="Derbyshire", Country="United Kingdom",  AddressType=AddressTypeEnum.Home}},
                EmailAddresses = new List<EmailAddress> { new EmailAddress { Address = "jack.smith@gs.com", EmailAddressType = EmailAddressTypeEnum.Work },
                    new EmailAddress { Address = "jack.smith@gmail.com", EmailAddressType = EmailAddressTypeEnum.Private }},
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "0044 0114 248 3294", PhoneNumberType = PhoneNumberTypeEnum.Home } }
            };

            Console.WriteLine("Persisting patient...");
            try
            {
                peopleService.AddPerson(person);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }

            Console.WriteLine("Populating: Linda Robster");
            person = new Person
            {
                Title = "Mr",
                FirstName = "Linda",
                MiddleName = "",
                LastName = "Robster",
                Sex = "F",
                DateOfBirth = new DateTime(1942, 8, 11),
                Employer = "BBC",
                //Qualifications = "",
                Occupation = "TV presenter",
                Salutation = "Dear",
                PersonType = PersonTypeEnum.Patient,
                Addresses = new List<Address>{new Address{AddressLine1="12 Red Square",AddressLine2="", Town="Wimbledon",
                   PostCode="SW19 8PS", StateCounty="Greater London", Country="United Kingdom",  AddressType=AddressTypeEnum.Home}},
                EmailAddresses = new List<EmailAddress> { new EmailAddress { Address = "linda.robster@gs.com", EmailAddressType = EmailAddressTypeEnum.Work },
                    new EmailAddress { Address = "jack.smith@gmail.com", EmailAddressType = EmailAddressTypeEnum.Private }},
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = "0044 0114 556 787899", PhoneNumberType = PhoneNumberTypeEnum.Home } }
            };

            Console.WriteLine("Persisting patient...");
            try
            {
                peopleService.AddPerson(person);
                Console.WriteLine("Patient persisted correctly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure persisting patient: {0}", ex.InnerException);
            }
        }

        public void ShowAllPatients()
        {
            var allPatients = peopleService.GetAllPatients();

            Console.WriteLine("ALL Patients:");
            DisplayPeople(allPatients);

        }

        public void SearchPatientByName()
        {
            Console.WriteLine("Searching patients containg 'Rob' in first, middle or last name:");

            var searchResults = peopleService.SearchByNameAndType("Rob", PersonTypeEnum.Patient);
            Console.WriteLine("Patients Patients:");
            DisplayPeople(searchResults);
        }

        public void UpdatePersonDetails()
        {
            var peopleService = new PeopleService();
            Console.WriteLine("We search for a person:");

            Person p = peopleService.SearchByNameAndType("Roberto", PersonTypeEnum.Patient).First();
            Console.WriteLine("Retrieved person:");
            Console.WriteLine(string.Format("{0} {1} {2}", p.FirstName, p.MiddleName, p.LastName));

            Console.WriteLine("Middle name changed to Giovanni");
            //we change the middle name to Giovanni
            p.MiddleName = "Giovanni";

            //we update
            peopleService.UpdatePerson(p);
            Console.WriteLine("Change persisted to db");

            //we retrieve the person back from the database
            var searchResults = peopleService.SearchByNameAndType("Roberto", PersonTypeEnum.Patient);
            Console.WriteLine("Retrieved persons:");
            DisplayPeople(searchResults);
        }

   
        public void DisplayPeople(IEnumerable<Person> patients)
        {
            var sortedPatients = patients
                .OrderBy(p => p.FirstName);

            foreach (var p in sortedPatients)
            {
                Console.WriteLine(string.Format("{0} {1} {2}", p.FirstName, p.MiddleName, p.LastName));
            }
        }

    }
}
