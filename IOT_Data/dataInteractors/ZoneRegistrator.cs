using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOT_Data.dataInteractors
{
    public class ZoneRegistrator : IZoneRegistrator
    {
        public void registerZoneEntry(ZoneAreaData zone)
        {
            throw new NotImplementedException();
        }

        public void registerZoneExit(ZoneAreaData zone)
        {
            throw new NotImplementedException();
        }

        public void registerZonePass(ZoneAreaData zone)
        {
            try
            {
                using var context = new SmartCityZoneContext();

                zone.Vehicle = context.Vehicles.Where(x => x.VehicleId == zone.Vehicle.VehicleId).First();
                zone.Sensor = context.Sensors.Where(x => x.SensorId == zone.Sensor.SensorId).First();

                context.Add(zone);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a area entry");
                throw e;
            }
        }
    }
}
