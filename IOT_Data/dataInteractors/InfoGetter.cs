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

        public Zone QueryZone(long zoneId)
        {
            using var context = new SmartCityZoneContext();
            return context.Zones.ToList()
                                  .Where(x => x.ZoneId == zoneId)
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
    }
}
