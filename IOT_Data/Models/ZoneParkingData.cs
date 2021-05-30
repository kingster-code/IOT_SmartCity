using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class ZoneParkingData
    {
        [Key]
        public int ZoneParkingId { get; set; }
        [Required]
        public Sensor Sensor { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
        public TimeSpan? Duration { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
