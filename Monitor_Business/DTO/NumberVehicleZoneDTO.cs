using System;

namespace Monitor_Business.DTO
{
    public class NumberVehicleZoneDTO
    {
        public string Zone { get; set; }
        public int Vehicles{ get; set; }

        public NumberVehicleZoneDTO()
        {
            Zone = "";
            Vehicles = 0;
        }

        public NumberVehicleZoneDTO(string zone,
            int vehicleid)
        {
            Zone = zone;
            Vehicles = vehicleid;
        }
    }
}
