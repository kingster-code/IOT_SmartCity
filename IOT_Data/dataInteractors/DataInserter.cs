using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOT_Data.dataInteractors
{
    public class DataInserter : IDataInserter
    {
        public void InsertRegisterAtmosphere(AtmData atm)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(atm);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a AtmData");
                throw e;
            }
        }

        public void InsertRegisterAtmospheres(List<AtmData> atmList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(atmList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering AtmDatas");
                throw e;
            }
        }

        public void InsertRegisterRobery(VehicleRoberyData robery)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(robery);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Robery");
                throw e;
            }
        }

        public void InsertRegisterRoberys(List<VehicleRoberyData> roberyList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(roberyList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering Roberys");
                throw e;
            }
        }

        public void InsertRegisterSensor(Sensor sensor)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(sensor);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Sensor");
                throw e;
            }
        }

        public void InsertRegisterSensors(List<Sensor> sensorList)
        {
            try
            {
                using var context = new SmartCityZoneContext();

                sensorList = sensorList.Select(x => new Sensor
                {
                    Zone = context.Zones.Where(y => y.ZoneId == x.Zone.ZoneId).First(),
                    SensorId = x.SensorId,
                    Type = context.SensorTypes.Where(y => y.TypeId == x.Type.TypeId).First()
                }).ToList();

                context.AddRange(sensorList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering Sensors");
                throw e;
            }
        }

        public void InsertRegisterSensorType(SensorType type)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(type);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a SensorType");
                throw e;
            }
        }

        public void InsertRegisterSensorTypes(List<SensorType> sensorTypeList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(sensorTypeList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering SensorTypes");
                throw e;
            }
        }

        public void InsertRegisterVehicle(Vehicle vehicle)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(vehicle);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Vehicle");
                throw e;
            }
        }

        public void InsertRegisterVehicles(List<Vehicle> vehicleList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(vehicleList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering Vehicles");
                throw e;
            }
        }

        public void InsertRegisterZone(Zone zone)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zone);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Zone");
                throw e;
            }
        }

        public void InsertRegisterZones(List<Zone> zoneList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(zoneList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering Zones");
                throw e;
            }
        }

        public void InsertRegisterZoneArea(ZoneAreaData zoneArea)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zoneArea);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a ZoneAreaData");
                throw e;
            }
        }

        public void InsertRegisterZoneAreas(List<ZoneAreaData> zoneAreaList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(zoneAreaList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering ZoneAreaDatas");
                throw e;
            }
        }

        public void InsertRegisterZoneParking(ZoneParkingData zoneParking)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zoneParking);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering ar ZoneParking");
                throw e;
            }
        }

        public void InsertRegisterZoneParkings(List<ZoneParkingData> zoneParkingList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.AddRange(zoneParkingList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering ZoneParkings");
                throw e;
            }
        }
    }
}
