namespace SimulatorBusiness.DTO
{
    public abstract class Sensor
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