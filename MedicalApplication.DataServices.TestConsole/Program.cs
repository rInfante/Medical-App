using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalApplication.DataServices.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleServiceTest = new PeopleServiceTest();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Wipe out data");
            peopleServiceTest.DeleteAllPeople();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Add Patient");
            peopleServiceTest.AddNewPatient_FullInformation();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Prepopulating patients");
            peopleServiceTest.PrePopulateVariousPatients();

            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Show All Patients");
            peopleServiceTest.ShowAllPatients();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Search of a patient by name (either first, middle or surname)");
            peopleServiceTest.SearchPatientByName();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Edit existing person");
            peopleServiceTest.UpdatePersonDetails();

            var contactDetailsServiceTest = new ContactDetailsServiceTest();
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Adding new address to person");
            contactDetailsServiceTest.AddAddressToPerson();
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Adding new email address to person");
            contactDetailsServiceTest.AddEmailAddressToPerson();
            /*
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Testing: Editing and Updating existing address");
            contactDetailsServiceTest.UpdateAddress();

            //same idea for phone numbers
            //phone numbers are added to a person via the method: contactDetailsService.AddPhoneNumberToPerson(newPhone, person);


            */

            Console.WriteLine("Hit a key to finish");
            Console.ReadKey();
        }
    }
}
