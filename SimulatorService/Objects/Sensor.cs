namespace SimulatorService.Objects
{
    public class Sensor
    {
        public Zone AtachedZone { get; set; }
        public long Id { get; set; }

        public Sensor(long id, Zone atachedZone)
        {
            AtachedZone = atachedZone;
            Id = id;
        }
    }
}