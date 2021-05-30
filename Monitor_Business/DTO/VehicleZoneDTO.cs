using System;

namespace Monitor_Business.DTO
{
    public class VehicleZoneDTO
    {
        public string Zone { get; set; }
        public int VehicleID { get; set; }

        public VehicleZoneDTO()
        {
            Zone = "";
            VehicleID = 0;
        }

        public VehicleZoneDTO(string zone,
            int vehicleid)
        {
            Zone = zone;
            VehicleID = vehicleid;
        }
    }
}
