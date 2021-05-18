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
        private readonly IDataInserter _inserter;
        private readonly IDataPurger _purger;
        private readonly IInfoGetter _dataGetter;

        public DataBaseFlusher(IDataInserter inserter, IDataPurger purger, IInfoGetter dataGetter)
        {
            _inserter = inserter;
            _purger = purger;
            _dataGetter = dataGetter;
        }

        /// <summary>
        /// Purges all data from the database.
        /// </summary>
        public void PurgeDataBase()
        {
            _purger.FlushAllData();
        }

        public void CreateDataBase(List<DTO.Zone> _zones, List<Car> _cars, List<ZoneSensor> _sensors, List<AirSensor> _airSensors)
        {
            InsertAllZones(_zones);
            InsertAllCars(_cars);
            SensorType zoneSensorType, airSensorType;
            InsertSensorTypes(out zoneSensorType, out airSensorType);

            _inserter.InsertRegisterSensors(_sensors.Select(x => new IOT_Data.Models.Sensor
            {
                //Zone = zoneList.Where(y => y.ZoneId == x.AtachedZone.ZoneID).First(),
                Zone = _dataGetter.QueryZone(x.AtachedZone.ZoneID),
                Type = zoneSensorType
            }).ToList());

            _inserter.InsertRegisterSensors(_airSensors.Select(x => new IOT_Data.Models.Sensor
            {
                //Zone = zoneList.Where(y => y.ZoneId == x.AtachedZone.ZoneID).First(),
                Zone = _dataGetter.QueryZone(x.AtachedZone.ZoneID),
                Type = airSensorType
            }).ToList());
        }

        /// <summary>
        /// Inserts all given sensor types to the DB.
        /// </summary>
        /// <param name="zoneSensorType"></param>
        /// <param name="airSensorType"></param>
        private void InsertSensorTypes(out SensorType zoneSensorType, out SensorType airSensorType)
        {
            zoneSensorType = new SensorType { SensorName = "zoneSensor", TypeId = 1 };
            airSensorType = new SensorType { SensorName = "airSensor", TypeId = 2 };
            _inserter.InsertRegisterSensorType(zoneSensorType);
            _inserter.InsertRegisterSensorType(airSensorType);
        }

        /// <summary>
        /// Inserts all given cars to the DB.
        /// </summary>
        /// <param name="_cars"></param>
        private void InsertAllCars(List<Car> _cars)
        {
            _inserter.InsertRegisterVehicles(_cars.Select(x => new Vehicle
            {
                Operational = true,
                VehicleId = (int)x._rfid
            }).ToList());
        }

        /// <summary>
        /// Inserts all given zones to the DB.
        /// </summary>
        /// <param name="_zones"></param>
        private void InsertAllZones(List<DTO.Zone> _zones)
        {
            var zoneList = _zones.Select(x => new IOT_Data.Models.Zone
            {
                ZoneId = (int)x.ZoneID,
                Name = x.ZoneID.ToString()
            }).ToList();

            _inserter.InsertRegisterZones(zoneList);
        }
    }
}
