using IOT_Data.Data;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOT_Data.dataInteractors
{
    public class InfoGetter : IInfoGetter
    {
        public AtmData QueryAtmosphere(long atmId)
        {
            using var context = new SmartCityZoneContext();
            return context.AtmosphereData.ToList()
                                  .Where(x => x.AtmreadId == atmId)
                                  .FirstOrDefault();
        }


        public Sensor QuerySensor(long sensorId)
        {
            using var context = new SmartCityZoneContext();
            return context.Sensors.ToList()
                                  .Where(x => x.SensorId == sensorId)
                                  .FirstOrDefault();
        }



        public SensorType QuerySensorType(long typeId)
        {
            using var context = new SmartCityZoneContext();
            return context.SensorTypes.ToList()
                                  .Where(x => x.TypeId == typeId)
                                  .FirstOrDefault();
        }

        public Vehicle QueryVehicle(long vehicleId)
        {
            using var context = new SmartCityZoneContext();
            return context.Vehicles.ToList()
                                  .Where(x => x.VehicleId == vehicleId)
                                  .FirstOrDefault();
        }

        public VehicleRoberyData QueryRobery(long roberyId)
        {
            using var context = new SmartCityZoneContext();
            return context.VehicleRoberies.ToList()
                                  .Where(x => x.VehicleRoberyId == roberyId)
                                  .FirstOrDefault();
        }
        public ZoneAreaData QueryZoneArea(long zoneAreaId)
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneAreas.ToList()
                                  .Where(x => x.ZoneAreaId == zoneAreaId)
                                  .FirstOrDefault();
        }
        public ZoneParkingData QueryZoneParking(long zoneParkingId)
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneParkingRegister.ToList()
                                  .Where(x => x.ZoneParkingId == zoneParkingId)
                                  .FirstOrDefault();
        }









        public int QueryZoneRobery(int zoneId)
        {
            using var context = new SmartCityZoneContext();
            return context.VehicleRoberies
                                  .Where(x => x.Zone.ZoneId == zoneId)
                                  .Count();
        }
        public IEnumerable<AtmData> QueryAtmosphereList(int atmId)
        {
            using var context = new SmartCityZoneContext();
            return context.AtmosphereData.Where(x => x.Sensor.Zone.ZoneId == atmId);
        }
        public int QueryZonePassage(int zoneId)
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneAreas
                                  .Where(x => x.Sensor.Zone.ZoneId == zoneId)
                                  .Count();
        }

        public List<VehicleRoberyData> QueryGetRoberyList()
        {
            using var context = new SmartCityZoneContext();
            return context.VehicleRoberies.ToList();
        }

        public Zone QueryZone(long zoneId)
        {
            using var context = new SmartCityZoneContext();
            return context.Zones.ToList()
                                  .Where(x => x.ZoneId == zoneId)
                                  .FirstOrDefault();
        }
        public List<Zone> QueryGetZoneList()
        {
            using var context = new SmartCityZoneContext();
            return context.Zones.ToList();
        }





        public int QueryNumberSensor(int id)
        {
            using var context = new SmartCityZoneContext();
            return context.Sensors.Where(s => s.Zone.ZoneId == id).Count();

        }



        public IEnumerable<ZoneParkingData> QueryZoneParkingList(int zoneParkingId)
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneParkingRegister
                                  .Where(x => x.Sensor.Zone.ZoneId == zoneParkingId).ToList();
        }
        public IEnumerable<ZoneParkingData> QueryZoneParkingList()
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneParkingRegister;
        }


    }
}
