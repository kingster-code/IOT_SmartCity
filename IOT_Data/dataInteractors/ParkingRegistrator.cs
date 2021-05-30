using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOT_Data.dataInteractors
{
    public class ParkingRegistrator : IParkingRegistrator
    {
        public void registerParkEntery(ZoneParkingData parkingData)
        {
            try
            {
                using var context = new SmartCityZoneContext();

                parkingData.Vehicle = context.Vehicles
                    .Where(x => x.VehicleId == parkingData.Vehicle.VehicleId)
                    .First();
                parkingData.Sensor = context.Sensors
                    .Where(x => x.SensorId == parkingData.Sensor.SensorId)
                    .First();

                context.Add(parkingData);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void registerParkExit(long carRfid)
        {
            try
            {
                using var context = new SmartCityZoneContext();

                var parkingData = context.ZoneParkingRegister
                    .OrderByDescending(x => x.Date)
                    .Where(x => x.Vehicle.VehicleId == carRfid)
                    .FirstOrDefault();
                parkingData.Duration = DateTime.Now - parkingData.Date;

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
