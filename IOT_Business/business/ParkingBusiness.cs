using IOT_Business.DTO;
using IOT_Business.interfaces;
using IOT_Data.interfaces;
using IOT_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Business.business
{
    public class ParkingBusiness : IParkingBusiness
    {
        private readonly IInfoGetter _datagetter;
        private readonly IParkingRegistrator _parkingReg;

        public ParkingBusiness(IInfoGetter datagetter, IParkingRegistrator parkingReg)
        {
            _datagetter = datagetter;
            _parkingReg = parkingReg;
        }

        public void RegisterParkEntery(ParkingDTO zoneReg)
        {
            var parkingData = new ZoneParkingData
            {
                Vehicle = _datagetter.QueryVehicle(zoneReg.RfidCar),
                Sensor = _datagetter.QuerySensor(zoneReg.Sensor),
                Date = DateTime.Now
            };

            _parkingReg.registerParkEntery(parkingData);
        }

        public void RegisterParkExit(long id)
        {
            _parkingReg.registerParkExit(id);
        }
    }
}
