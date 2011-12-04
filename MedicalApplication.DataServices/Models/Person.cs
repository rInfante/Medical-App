using System;
using System.Collections.Generic;

namespace MedicalApplication.DataServices.Models
{
   
    public partial class Person
    {
        public Person()
        {
            this.Addresses = new List<Address>();
            this.PhoneNumbers = new List<PhoneNumber>();
            this.EmailAddresses = new List<EmailAddress>();
        }
    
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Salutation { get; set; }
        public string Qualifications { get; set; }
        public PersonTypeEnum PersonType { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Employer { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }

        public void PopulateFromPerson(Person person)
        {
            this.Title = person.Title;
            this.FirstName = person.FirstName;
            this.MiddleName = person.MiddleName;
            this.LastName = person.LastName;
            this.Sex = person.Sex;
            this.DateOfBirth = person.DateOfBirth;

            this.Occupation = person.Occupation;
            this.Qualifications = person.Qualifications;
            this.Salutation = person.Salutation;
            this.PersonType = person.PersonType;
        }

        public bool HasName(string name)
        {
            string lowerName = name.ToLower();

            return LastName.ToLower().Contains(lowerName)
                    || FirstName.ToLower().Contains(lowerName)
                    || MiddleName.ToLower().Contains(lowerName);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} - Sex: {4} - DOB: {5} - {6} - {7} - {8} - {9}",
                Title, FirstName, MiddleName, LastName, Sex, DateOfBirth, Occupation, Qualifications, Salutation,
                (PersonTypeEnum)PersonType);
        }
    }
}
