using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.interfaces
{
    public interface IZoneRegistrator
    {
        void registerZoneExit(ZoneAreaData zone);
        void registerZoneEntry(ZoneAreaData zone);
        void registerZonePass(ZoneAreaData zone);
    }
}
