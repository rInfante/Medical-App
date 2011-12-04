using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MedicalApplication.DataServices.Models;

namespace MedicalApplication.DataServices.Services
{
    public interface IContactDetailsService
    {
        void AddAddressToPerson(Address address, string personId);
        void AddAddressToPerson(Address address, Person person);
        IEnumerable<Address> GetAddressesByPerson(string personId);
        void AddEmailAddressToPerson(EmailAddress address, string personId);
        void AddEmailAddressToPerson(EmailAddress address, Person person);
    }
}
