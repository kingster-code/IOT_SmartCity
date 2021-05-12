using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IOT_Data.Models
{
    public class Zone
    {
        [Key]
        public int ZoneId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
