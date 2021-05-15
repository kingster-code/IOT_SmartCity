using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.interfaces
{
    public interface IDataInserter
    {
        void InsertRegisterAtmosphere(AtmData atm);
        void InsertRegisterSensor(Sensor sensor);
        void InsertRegisterSensorType(SensorType type);
        void InsertRegisterVehicle(Vehicle vehicle);
        void InsertRegisterRobery(VehicleRoberyData robery);
        void InsertRegisterZone(Zone zone);
        void InsertRegisterZoneArea(ZoneAreaData zoneArea);
        void InsertRegisterZoneParking(ZoneParkingData zoneParking);


        void InsertRegisterAtmospheres(List<AtmData> atm);
        void InsertRegisterSensors(List<Sensor> sensor);
        void InsertRegisterSensorTypes(List<SensorType> type);
        void InsertRegisterVehicles(List<Vehicle> vehicle);
        void InsertRegisterRoberys(List<VehicleRoberyData> robery);
        void InsertRegisterZones(List<Zone> zone);
        void InsertRegisterZoneAreas(List<ZoneAreaData> zoneArea);
        void InsertRegisterZoneParkings(List<ZoneParkingData> zoneParking);
    }
}
