using System;
using System.Collections.Generic;

#nullable disable

namespace COMP586.Models
{
    public partial class Owner
    {
        public Owner()
        {
            VehicleInfos = new HashSet<VehicleInfo>();
        }

        public int OwnerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Dob { get; set; }
        public string LicenseNum { get; set; }
        public int LicenseStatus { get; set; }
        public string StateResidence { get; set; }

        public virtual ICollection<VehicleInfo> VehicleInfos { get; set; }
    }
}
