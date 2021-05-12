using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class ZoneAreaData
    {
        [Key]
        public int ZoneAreaId { get; set; }
        [Required]
        public Sensor Sensor { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
