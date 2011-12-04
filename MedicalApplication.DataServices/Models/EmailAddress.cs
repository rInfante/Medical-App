using System;

namespace MedicalApplication.DataServices.Models
{
    public partial class EmailAddress
    {   
        public string Id { get; set; }
        public string Address { get; set; }
        public EmailAddressTypeEnum EmailAddressType { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public void PopulateFromEmailAddress(EmailAddress emailAddress)
        {
            this.Address = emailAddress.Address;
            this.EmailAddressType = emailAddress.EmailAddressType;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Address, EmailAddressType);
        }
    }
}
