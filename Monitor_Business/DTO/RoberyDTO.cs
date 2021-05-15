using System;
using IOT_Data.Models;

namespace Monitor_Business.DTO
{
    public class RoberyDTO
    {
        public string ZonaName { get; set; }
        public int NumberSteels { get; set; }

        public RoberyDTO(string nome, int number)
        {
            ZonaName = nome;
            NumberSteels = number;
        }

        public RoberyDTO()
        {
            ZonaName = "";
            NumberSteels = 0;
        }

    }
}
