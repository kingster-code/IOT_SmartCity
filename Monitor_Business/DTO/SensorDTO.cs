using System;
using IOT_Data.Models;

namespace Monitor_Business.DTO
{
    public class SensorDTO
    {
        public int ZonaId { get; set; }
        public int NumberSensor { get; set; }

        public SensorDTO(int sensorId, int number)
        {
            ZonaId = sensorId;
            NumberSensor = number;
        }

        public SensorDTO()
        {
            ZonaId = 0;
            NumberSensor = 0;
        }

    }
}
