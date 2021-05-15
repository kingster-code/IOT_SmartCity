using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterAtmospheres(List<AtmData> atmList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(atmList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterRoberys(List<VehicleRoberyData> roberyList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(roberyList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterSensors(List<Sensor> sensorList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(sensorList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterSensorTypes(List<SensorType> sensorTypeList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(sensorTypeList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterVehicles(List<Vehicle> vehicleList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(vehicleList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterZones(List<Zone> zoneList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zoneList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterZoneAreas(List<ZoneAreaData> zoneAreaList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zoneAreaList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
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
                Console.WriteLine("Problem connecting to DB when registering a Atmosphere reading");
                throw e;
            }
        }

        public void InsertRegisterZoneParkings(List<ZoneParkingData> zoneParkingList)
        {
            try
            {
                using var context = new SmartCityZoneContext();
                context.Add(zoneParkingList);
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
