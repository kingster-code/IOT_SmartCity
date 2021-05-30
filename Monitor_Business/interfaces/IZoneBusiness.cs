using IOT_Data.Models;
using Monitor_Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor_Business.interfaces
{
    public interface IZoneBusiness
    {
        public List<AtmData> GetAtmZone24Hour(int zoneid);
        public List<AtmMesDTO> GetAtmZoneLast3Months();
        public List<AtmMesDTO> ZoneAtmMonth(DateTime ano, int atmId);
        public List<AtmMesDTO> GetAtmZoneLastMonth(int zoneid);
        public int GetNumberZones();
        int GetNumberSensores();
        int GetNumberRoberys();
        public List<NumberVehicleZoneDTO> NumberVehicleZone();
        List<NumberVehicleZoneDTO> NumberVehiclePark();
    }
}
