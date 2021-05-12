using IOT_Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Business.interfaces
{
    public interface IZoneBusiness
    {
        public void RegisterZone(ZoneInfo zoneReg);
        public void RegisterZoneAtm(ZoneAtmInfo zoneAtm);
    }
}
