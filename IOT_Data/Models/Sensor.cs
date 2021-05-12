using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class Sensor
    {
        [Key]
        public int SensorId { get; set; }
        [Required]
        public Zone Zone { get; set; }
        public SensorType Type { get; set; }
    }
}
