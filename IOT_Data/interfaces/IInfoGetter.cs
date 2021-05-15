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


        List<VehicleRoberyData> QueryGetRoberyList();
        List<Zone> QueryGetZoneList();
        int QueryNumberSensor(int id);
        IEnumerable<AtmData> QueryAtmosphereList(int atmId);
        int QueryZoneRobery(int zoneId);
        int QueryZonePassage(int zoneId);
        IEnumerable<ZoneParkingData> QueryZoneParkingList();
        public IEnumerable<ZoneParkingData> QueryZoneParkingList(int zoneParkingId);
    }
}
