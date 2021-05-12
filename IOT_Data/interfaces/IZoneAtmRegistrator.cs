using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.interfaces
{
    public interface IZoneAtmRegistrator
    {
        void registerZoneAtm(AtmData zoneAtmDataInfo);
    }
}
