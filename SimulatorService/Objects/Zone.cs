using System.Collections.Generic;

namespace SimulatorService.Objects
{
    public class Zone
    {
        public long SensorID { get; set; }
        public List<ZoneSensor> zoneSensors { get; set; }
        public List<AirSensor> airSensors { get; set; }

        public Zone(long sensorID)
        {
            SensorID = sensorID;
        }
    }
}