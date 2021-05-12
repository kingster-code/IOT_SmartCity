using System;

namespace IOT_Business.DTO
{
    public class ZoneInfo
    {
        public long Zone { get; set; }
        public long Sensor { get; set; }
        public long Rfid { get; set; }
        public DateTime date { get; }

        public ZoneInfo()
        {
            date = DateTime.Now;
        }

        public ZoneInfo(long zone, long sensor, long rfid)
        {
            Zone = zone;
            Sensor = sensor;
            Rfid = rfid;
            date = DateTime.Now;
        }
    }
}