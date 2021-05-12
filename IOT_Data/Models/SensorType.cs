using System.ComponentModel.DataAnnotations;

namespace IOT_Data.Models
{
    public class SensorType
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string SensorName { get; set; }
    }
}