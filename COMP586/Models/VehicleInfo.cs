using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace COMP586.Models
{
    [Table("VehicleInfo")]
    public partial class VehicleInfo
    {
        [Key]
        [Column("vehicleID")]
        public int VehicleId { get; set; }

        [Required]
        [Column("VIN")]
        [StringLength(17)]
        public string Vin { get; set; }

        [Column("modelYear")]
        public int ModelYear { get; set; }

        [Required]
        [Column("make")]
        [StringLength(25)]

        public string Make { get; set; }
        [Required]
        [Column("model")]
        [StringLength(25)]
        public string Model { get; set; }

        [Column("color")]
        [StringLength(15)]
        public string Color { get; set; }

        [Column("mileage")]
        public int? Mileage { get; set; }

        [Column("ownerID")]
        public int? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [InverseProperty("VehicleInfos")]
        public virtual Owner Owner { get; set; }
    }
}
