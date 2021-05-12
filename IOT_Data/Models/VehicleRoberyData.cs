using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class VehicleRoberyData
    {
        [Key]
        public int VehicleRoberyId { get; set; }
        [Required]
        public Zone Zone { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public bool Resolved { get; set; }
    }
}
