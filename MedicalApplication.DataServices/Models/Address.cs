using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalApplication.DataServices.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Town { get; set; }
        public string StateCounty { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public AddressTypeEnum AddressType { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public void PopulateFromAddress(Address address)
        {
            this.AddressLine1 = address.AddressLine1;
            this.AddressLine2 = address.AddressLine2;
            this.AddressLine3 = address.AddressLine3;
            this.Town = address.Town;
            this.StateCounty = address.StateCounty;
            this.PostCode = address.PostCode;
            this.Country = address.Country;
            this.AddressType = address.AddressType;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}",
                AddressLine1, AddressLine2, AddressLine3, Town, StateCounty, PostCode, Country, (AddressTypeEnum)AddressType);
        }
    }
}
