using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class AtmData
    {
        [Key]
        public int AtmreadId { get; set; }
        [Required]
        public Sensor Sensor { get; set; }

        public double CO2 { get; set; }
        public double CO { get; set; }
        public double HC { get; set; }
        public double Rcho { get; set; }
        public double NOx { get; set; }
        public double SOx { get; set; }
        public double MP { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
