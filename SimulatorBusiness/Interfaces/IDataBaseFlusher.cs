using SimulatorBusiness.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorBusiness.Interfaces
{
    public interface IDataBaseFlusher
    {
        void PurgeDataBase();
        void CreateDataBase(List<Zone> _zones, List<Car> _cars, List<ZoneSensor> _sensors, List<AirSensor> _airSensors);
    }
}
