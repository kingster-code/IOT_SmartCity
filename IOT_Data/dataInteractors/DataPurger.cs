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
                Console.WriteLine("REmoving all data from AtmosphereData");
                context.AtmosphereData.ToList().ForEach(x => context.AtmosphereData.Remove(x));
                Console.WriteLine("REmoving all data from Sensors");
                context.Sensors.ToList().ForEach(x => context.Sensors.Remove(x));
                Console.WriteLine("REmoving all data from SensorTypes");
                context.SensorTypes.ToList().ForEach(x => context.SensorTypes.Remove(x));
                Console.WriteLine("REmoving all data from Vehicles");
                context.Vehicles.ToList().ForEach(x => context.Vehicles.Remove(x));
                Console.WriteLine("REmoving all data from VehicleRoberies");
                context.VehicleRoberies.ToList().ForEach(x => context.VehicleRoberies.Remove(x));
                Console.WriteLine("REmoving all data from Zones");
                context.Zones.ToList().ForEach(x => context.Zones.Remove(x));
                Console.WriteLine("REmoving all data from ZoneAreas");
                context.ZoneAreas.ToList().ForEach(x => context.ZoneAreas.Remove(x));
                Console.WriteLine("REmoving all data from ZoneParkingRegister");
                context.ZoneParkingRegister.ToList().ForEach(x => context.ZoneParkingRegister.Remove(x));

            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when purging");
                throw e;
            }
        }
    }
}
