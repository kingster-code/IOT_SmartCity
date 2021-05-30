namespace SimulatorBusiness.DTO
{
    public class Car
    {
        public long _rfid { get; set; }
        public Zone _zone { get; set; }
        public bool _parked { get; set; }

        public Car(long rfid, Zone zone)
        {
            _rfid = rfid;
            _zone = zone;
        }
    }
}