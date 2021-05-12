using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public bool Operational { get; set; }
    }
}
