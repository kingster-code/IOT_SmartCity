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

            Random a = new Random();
          
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
        public List<AtmData> QueryAtmosphereZoneList(int id)
        {
            using var context = new SmartCityZoneContext();
            return context.AtmosphereData.Where(s=>s.Sensor.Zone.ZoneId==id).ToList();
        }
        public List<AtmData> QueryAtmosphereList()
        {
            using var context = new SmartCityZoneContext();
            return context.AtmosphereData.ToList();
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


        public IEnumerable<string> QueryGetZoneNamesIEnumerable()
        {
            using var context = new SmartCityZoneContext();
            return context.Zones.Select(s=>s.Name);
        }

        public IEnumerable<ZoneAreaData> QueryZoneAreaList()
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneAreas;
        }

        public int QueryNumberSensor(int id)
        {
            using var context = new SmartCityZoneContext();
            return context.Sensors.Where(s => s.Zone.ZoneId == id).Count();

        }

        

       

        public string QueryZoneAreaVehicle(int vehicleId)
        {
            using var context = new SmartCityZoneContext();

            return context.ZoneAreas.Where(s => s.Vehicle.VehicleId == vehicleId).OrderByDescending(s => s.Date).Select(s=>s.Sensor.Zone.Name).First();
        }


        public int QueryParkZone(int id)
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneParkingRegister.Where(a => a.Duration == null && a.Sensor.Zone.ZoneId==id).Count();
        }

        public int QuerySensorZona(int id)
        {
            using var context = new SmartCityZoneContext();
            return context.Sensors.First(s => s.SensorId == id).Zone.ZoneId;
        }

        public IEnumerable<Vehicle> QueryVehicleDistinctZoneData()
        {
            using var context = new SmartCityZoneContext();
            return context.ZoneAreas.Select(s=>s.Vehicle).Distinct().ToList();
        }

        public int QueryNumberZones()
        {
            using var context = new SmartCityZoneContext();
            return context.Zones.Distinct().Count();
        }

        public int QueryNumberRoberys()
        {
            using var context = new SmartCityZoneContext();
            return context.VehicleRoberies.Count();
        }

        public int QueryNumberSensores()
        {
            using var context = new SmartCityZoneContext();
            return context.Sensors.Distinct().Count();
        }

        public double QueryCo2Day(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var co2 = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.CO2);
            return co2.Sum() / co2.Count();
        }

        public double QueryCoDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var co = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.CO);
            return co.Sum() / co.Count();
        }

        public double QueryMpDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var aux = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.MP);
            return aux.Sum() / aux.Count();
        }

        public double QueryHcDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var aux = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.HC);
            return aux.Sum() / aux.Count();
        }

        public double QueryNOxDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var aux = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.NOx);
            return aux.Sum() / aux.Count();
        }

        public double QueryRchoDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var aux = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.Rcho);
            return aux.Sum() / aux.Count();
        }

        public double QuerySOxDay(DateTime date)
        {
            using var context = new SmartCityZoneContext();
            var aux = context.AtmosphereData.Where(s => s.Date.Date == date.Date).Select(a => a.SOx);
            return aux.Sum() / aux.Count();
        }
    }

}
