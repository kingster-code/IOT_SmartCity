using System;

namespace Monitor_Business.DTO
{
    public class AtmMesDTO
    {
        public string Zone { get; set; }
        public long Sensor { get; set; }
        public double Co2 { get; set; }
        public double Co { get; set; }
        public double Hc { get; set; }
        public double Rcho { get; set; }
        public double NOx { get; set; }
        public double SOx { get; set; }
        public double MP { get; set; }
        public DateTime ano { get; set; }

        public AtmMesDTO()
        {
            ano = DateTime.Now;
        }

        public AtmMesDTO(string nome,
            double co2,
            double co,
            double hc,
            double rcho,
            double nox,
            double sox,
            double mp,
            DateTime data)
        {
            Zone = nome;
            Co2 = co2;
            Co = co;
            Hc = hc;
            Rcho = rcho;
            NOx = nox;
            SOx = sox;
            MP = mp;

            ano = data;
        }
    }
}
