using System;

namespace MedicalApplication.DataServices.Models
{
    public partial class PhoneNumber
    {  
        public string Id { get; set; }
        public string Number { get; set; }
        public PhoneNumberTypeEnum PhoneNumberType { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
