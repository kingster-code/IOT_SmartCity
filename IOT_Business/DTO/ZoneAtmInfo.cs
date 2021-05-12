using System;

namespace IOT_Business.DTO
{
    public class ZoneAtmInfo
    {
        public long Zone { get; set; }
        public long Sensor { get; set; }
        public double Co2 { get; set; }
        public double Co { get; set; }
        public double Hc { get; set; }
        public double Rcho { get; set; }
        public double NOx { get; set; }
        public double SOx { get; set; }
        public double MP { get; set; }
        public DateTime date { get; }

        public ZoneAtmInfo()
        {
            date = DateTime.Now;
        }

        public ZoneAtmInfo(long zone,
            long sensor,
            double co2,
            double co,
            double hc,
            double rcho,
            double nox,
            double sox,
            double mp)
        {
            if (zone < 0) throw new ArgumentException("zone id must be positive and not null");
            if (sensor < 0) throw new ArgumentException("sensor id must be positive and not null");

            Zone = zone;
            Sensor = sensor;

            if (co2 < 0) throw new ArgumentException("co2 must be positive");
            if (co < 0) throw new ArgumentException("co must be positive");
            if (hc < 0) throw new ArgumentException("hc must be positive");
            if (rcho < 0) throw new ArgumentException("rcho must be positive");
            if (nox < 0) throw new ArgumentException("nox must be positive");
            if (sox < 0) throw new ArgumentException("sox must be positive");
            if (mp < 0) throw new ArgumentException("mp must be positive");

            Co2 = co2;
            Co = co;
            Hc = hc;
            Rcho = rcho;
            NOx = nox;
            SOx = sox;
            MP = mp;

            date = DateTime.Now;
        }
    }
}
