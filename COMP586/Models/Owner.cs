using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace COMP586.Models
{
    [Table("Owner")]
    public partial class Owner
    {
        public Owner()
        {
            VehicleInfos = new HashSet<VehicleInfo>();
        }

        [Key]
        [Column("ownerID")]
        public int OwnerId { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("DOB")]
        public int Dob { get; set; }
        [Required]
        [StringLength(17)]
        public string LicenseNum { get; set; }
        public int LicenseStatus { get; set; }
        [Required]
        [Column("stateResidence")]
        [StringLength(2)]
        public string StateResidence { get; set; }

        [InverseProperty(nameof(VehicleInfo.Owner))]
        public virtual ICollection<VehicleInfo> VehicleInfos { get; set; }
    }
}
