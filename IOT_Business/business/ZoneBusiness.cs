using IOT_Business.DTO;
using IOT_Business.interfaces;
using IOT_Data.interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using IOT_Data.Models;

namespace IOT_Business.business
{
    public class ZoneBusiness : IZoneBusiness
    {
        private readonly IZoneRegistrator _zoneRegister;
        private readonly IZoneAtmRegistrator _zoneAtmReg;
        private readonly IInfoGetter _datagetter;

        public ZoneBusiness(IZoneRegistrator zoneRegister, IZoneAtmRegistrator zoneAtmReg, IInfoGetter datagetter)
        {
            _zoneRegister = zoneRegister;
            _zoneAtmReg = zoneAtmReg;
            _datagetter = datagetter;
        }

        public void RegisterZone(ZoneInfo zoneReg)
        {
            var zone = new ZoneAreaData
            {
                Date = zoneReg.date,
                Sensor = _datagetter.QuerySensor(zoneReg.Sensor),
                Vehicle = _datagetter.QueryVehicle(zoneReg.Rfid)
            };

            _zoneRegister.registerZonePass(zone);
        }

        public void RegisterZoneAtm(ZoneAtmInfo zoneAtm)
        {
            var zoneAtmDataInfo = new AtmData
            {
                CO = zoneAtm.Co,
                CO2 = zoneAtm.Co2,
                Date = zoneAtm.date,
                HC = zoneAtm.Hc,
                MP = zoneAtm.MP,
                NOx = zoneAtm.NOx,
                Rcho = zoneAtm.Rcho,
                Sensor = _datagetter.QuerySensor(zoneAtm.Sensor),
                SOx = zoneAtm.SOx
            };

            _zoneAtmReg.registerZoneAtm(zoneAtmDataInfo);
        }
    }
}
