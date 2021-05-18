using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOT_Data.dataInteractors
{
    public class ZoneAtmRegistrator : IZoneAtmRegistrator
    {
        public void registerZoneAtm(AtmData zoneAtmDataInfo)
        {
            try
            {
                using var context = new SmartCityZoneContext();

                zoneAtmDataInfo.Sensor = context.Sensors.ToList().Where(x => x.SensorId == zoneAtmDataInfo.Sensor.SensorId).First();

                context.Add(zoneAtmDataInfo);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }
    }
}
