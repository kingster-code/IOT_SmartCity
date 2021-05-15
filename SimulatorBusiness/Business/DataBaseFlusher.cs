using IOT_Data.interfaces;
using IOT_Data.Models;
using SimulatorBusiness.DTO;
using SimulatorBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorBusiness.Business
{
    public class DataBaseFlusher : IDataBaseFlusher
    {
        public IDataInserter _inserter { get; set; }
        public IDataPurger _purger{ get; set; }

        public DataBaseFlusher(IDataInserter inserter, IDataPurger purger)
        {
            _inserter = inserter;
            _purger = purger;
        }

        public void CreateDataBase(List<DTO.Zone> _zones, List<Car> _cars, List<ZoneSensor> _sensors, List<AirSensor> _airSensors)
        {
            _inserter.InsertRegisterZones(_zones.Select(x => new IOT_Data.Models.Zone
            {
                Name = x.ZoneID.ToString()
            }).ToList());

            _inserter.InsertRegisterVehicles(_cars.Select(x => new Vehicle
            {
                Operational = true,
                VehicleId = (int)x._rfid
            }).ToList());

            var zoneSensorType = new SensorType { SensorName = "zoneSensor" };
            var airSensorType = new SensorType { SensorName = "airSensor" };
            _inserter.InsertRegisterSensorType(zoneSensorType);
            _inserter.InsertRegisterSensorType(airSensorType);

            _inserter.InsertRegisterSensors(_sensors.Select(x => new IOT_Data.Models.Sensor
            {
                Type = zoneSensorType
            }).ToList());

            _inserter.InsertRegisterSensors(_airSensors.Select(x => new IOT_Data.Models.Sensor
            {
                Type = airSensorType
            }).ToList());
        }

        public void PurgeDataBase()
        {
            _purger.FlushAllData();
        }
    }
}
