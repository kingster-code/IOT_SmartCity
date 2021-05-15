using System.Collections.Generic;

namespace SimulatorService.Objects
{
    public class Zone
    {
        public long ZoneID { get; set; }
        public List<ZoneSensor> zoneSensors { get; set; }
        public List<AirSensor> airSensors { get; set; }

        public Zone(long sensorID)
        {
            zoneSensors = new List<ZoneSensor>();
            airSensors = new List<AirSensor>();
            ZoneID = sensorID;
        }
    }
}