using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Business.DTO
{
    public class ParkingDTO
    {
        public long Zone { get; set; }
        public long Sensor { get; set; }
        public long RfidCar { get; set; }
        public DateTime date { get; }

        public ParkingDTO()
        {
            date = DateTime.Now;
        }

        public ParkingDTO(long zone, long sensor, long rfid)
        {
            Zone = zone;
            Sensor = sensor;
            RfidCar = rfid;
            date = DateTime.Now;
        }
    }
}
