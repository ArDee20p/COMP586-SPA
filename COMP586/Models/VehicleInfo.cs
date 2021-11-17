using System;
using System.Collections.Generic;

#nullable disable

namespace COMP586.Models
{
    public partial class VehicleInfo
    {
        public int VehicleId { get; set; }
        public string Vin { get; set; }
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int? Mileage { get; set; }
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}
