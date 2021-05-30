using IOT_Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Business.interfaces
{
    public interface IParkingBusiness
    {
        public void RegisterParkEntery(ParkingDTO zoneReg);
        public void RegisterParkExit(long id);
    }
}
