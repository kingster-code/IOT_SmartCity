using IOT_Data.Data;
using IOT_Data.interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.dataInteractors
{
    public class DataPurger : IDataPurger
    {
        public void FlushAllData()
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Database.EnsureCreated();

                Console.WriteLine("Removing all data from AtmosphereData");
                context.AtmosphereData.RemoveRange(context.AtmosphereData.ToList());
                Console.WriteLine("Removing all data from Sensors");
                context.Sensors.RemoveRange(context.Sensors.ToList());
                Console.WriteLine("Removing all data from SensorTypes");
                context.SensorTypes.RemoveRange(context.SensorTypes.ToList());
                Console.WriteLine("Removing all data from Vehicles");
                context.Vehicles.RemoveRange(context.Vehicles.ToList());
                Console.WriteLine("Removing all data from VehicleRoberies");
                context.VehicleRoberies.RemoveRange(context.VehicleRoberies.ToList());
                Console.WriteLine("Removing all data from Zones");
                context.Zones.RemoveRange(context.Zones.ToList());
                Console.WriteLine("Removing all data from ZoneAreas");
                context.ZoneAreas.RemoveRange(context.ZoneAreas.ToList());
                Console.WriteLine("Removing all data from ZoneParkingRegister");
                context.ZoneParkingRegister.RemoveRange(context.ZoneParkingRegister.ToList());

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when purging");
                throw e;
            }
        }
    }
}
