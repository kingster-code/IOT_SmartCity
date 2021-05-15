using System;
using System.Collections.Generic;
using System.Text;

namespace SimulatorService.Objects
{
    public class ZoneSensor : Sensor
    {
        public ZoneSensor(long id, Zone atachedZone) : base(id, atachedZone) { }
    }
}
