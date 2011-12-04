using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalApplication.DataServices.Models
{
    public enum PersonTypeEnum { Surgeon = 1, Patient = 2, Admin = 3 }
    public enum AddressTypeEnum { Home = 1, Work = 2, SecondHome = 3, Other = 4 };
    public enum EmailAddressTypeEnum { Private = 1, Work = 2, Other = 3 };
    public enum PhoneNumberTypeEnum { Home = 1, Work = 2, WorkMobile = 3, PrivateMobile = 4 };

}
