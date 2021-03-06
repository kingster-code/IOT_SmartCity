using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.interfaces
{
    public interface IInfoGetter
    {
        AtmData QueryAtmosphere(long atmId);
        Sensor QuerySensor(long sensor);
        SensorType QuerySensorType(long typeId);
        Vehicle QueryVehicle(long vehicleId);
        VehicleRoberyData QueryRobery(long roberyId);
        Zone QueryZone(long zoneId);
        ZoneAreaData QueryZoneArea(long zoneAreaId);
        ZoneParkingData QueryZoneParking(long zoneParkingId);


        
        int QueryNumberSensor(int id);
        List<AtmData> QueryAtmosphereZoneList(int id);

        List<AtmData> QueryAtmosphereList();
        int QueryZoneRobery(int zoneId);
        int QueryZonePassage(int zoneId);

        IEnumerable<ZoneAreaData> QueryZoneAreaList();
        IEnumerable<string> QueryGetZoneNamesIEnumerable();
        string QueryZoneAreaVehicle(int vehicleId);

        List<VehicleRoberyData> QueryGetRoberyList();
        List<Zone> QueryGetZoneList();
        IEnumerable<Vehicle> QueryVehicleDistinctZoneData();
        int QueryNumberZones();
        int QueryNumberSensores();
        int QueryNumberRoberys();
        int QueryParkZone(int id );
        double QueryCo2Day(DateTime date);
        double QueryCoDay(DateTime date);
        double QueryMpDay(DateTime date);
        double QueryHcDay(DateTime date);
        double QueryNOxDay(DateTime date);
        double QueryRchoDay(DateTime date);
        double QuerySOxDay(DateTime date);
        int QuerySensorZona(int id);
    }
}
