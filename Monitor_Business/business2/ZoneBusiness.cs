using Monitor_Business.DTO;
using Monitor_Business.interf;
using IOT_Data.interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using IOT_Data.Models;

namespace Monitor_Business.business2
{
    public class ZoneBusiness : IZoneBusiness
    {
        private readonly IZoneRegistrator _zoneRegister;
        private readonly IZoneAtmRegistrator _zoneAtmReg;
        private readonly IInfoGetter _datagetter;

        public ZoneBusiness(IZoneRegistrator zoneRegister, IZoneAtmRegistrator zoneAtmReg, IInfoGetter datagetter)
        {
            _zoneRegister = zoneRegister;
            _zoneAtmReg = zoneAtmReg;
            _datagetter = datagetter;
        }

       

        public IEnumerable<RoberyDTO> GetZoneNumberRobery()
        {
            List<Zone> lista = _datagetter.QueryGetZoneList();

            return lista.Select(item => new RoberyDTO
            {
                ZonaName = item.Name,
                NumberSteels = _datagetter.QueryZoneRobery(item.ZoneId)
            });


        }



        public List<AtmData> GetAtmZone24Hour(int zoneid)
        {
            return _datagetter.QueryAtmosphereZoneList(zoneid).Where(s => (s.Date.AddDays(1) >= DateTime.Now)).OrderBy(a => a.Date).ToList();



        }

        public List<AtmMesDTO> GetAtmZoneLastMonth(int zoneid)
        {
            
            return _datagetter.QueryAtmosphereZoneList(zoneid).Where(s => s.Date.AddMonths(1) >= DateTime.Now).OrderBy(a => a.Date).GroupBy(s=>s.Date.Day).Select(item=> new AtmMesDTO
            {
                Co = _datagetter.QueryCoDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                Co2 = _datagetter.QueryCo2Day(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                ano = new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key),
                Hc = _datagetter.QueryHcDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                MP = _datagetter.QueryMpDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                NOx = _datagetter.QueryNOxDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                Rcho = _datagetter.QueryRchoDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                SOx = _datagetter.QuerySOxDay(new DateTime(DateTime.Now.Year, DateTime.Now.Month, item.Key)),
                
            }).ToList();


        }

        public List<AtmMesDTO> GetAtmZoneLast3Months()
        {
            var data = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(0).Month, 01);
            var aux = _datagetter.QueryAtmosphereList().Where(s => s.Date >= data).OrderBy(a => a.Date).ToList();
            var ano = new List<AtmMesDTO>();
            for (int i = 0; i < 1; i++) {
                var a = new AtmMesDTO
                {
                    Co = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.CO).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    Co2 = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.CO2).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    ano = data.AddMonths(i),
                    Hc = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.HC).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    MP = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.MP).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    NOx = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.NOx).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    Rcho = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.Rcho).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    SOx = (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Select(s => s.SOx).Sum()) / (aux.Where(s => s.Date.Year == data.Year && s.Date.Month == data.AddMonths(i).Month).Count()),
                    Zone = "",
                };
                ano.Add(a);

            }

            return ano;
        }


      

        public List<NumberVehicleZoneDTO> NumberVehicleZone(){

               var veiculos = _datagetter.QueryVehicleDistinctZoneData().ToList();

               var vehiclezoneDTO = veiculos.AsParallel().Select(item => new VehicleZoneDTO
                    {

                        VehicleID = item.VehicleId,
                        Zone = _datagetter.QueryZoneAreaVehicle(item.VehicleId)
                    });
                    return vehiclezoneDTO.AsParallel().GroupBy(s => s.Zone).OrderBy(s=>s.Key).Select(item => new NumberVehicleZoneDTO
                    {
                        Zone = item.Key,
                        Vehicles = item.Count(),
                    }).ToList();



        }

        public List<NumberVehicleZoneDTO> NumberVehiclePark()
        {

            List<Zone> lista = _datagetter.QueryGetZoneList();
            return lista.Select(item => new NumberVehicleZoneDTO
            {
                Zone = item.ZoneId.ToString(),
                Vehicles = _datagetter.QueryParkZone(item.ZoneId),
            }).ToList();


        }





        public List<AtmMesDTO> ZoneAtmMonth(DateTime ano, int zoneId)
        {
            List<Zone> lista = _datagetter.QueryGetZoneList();
            var aux = _datagetter.QueryAtmosphereZoneList(zoneId).Where(s => s.Date.Year == ano.Year && s.Date.Month==ano.Month);

            return lista.Select(item => new AtmMesDTO
            {
                Co = (aux.Where(s=>s.Sensor.Zone.ZoneId==item.ZoneId).Select(s=>s.CO).Sum())/(aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                Co2 = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.CO2).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                ano = ano,
                Hc = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.HC).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                MP = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.MP).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                NOx = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.NOx).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                Rcho = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.Rcho).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                SOx = (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Select(s => s.SOx).Sum()) / (aux.Where(s => s.Sensor.Zone.ZoneId == item.ZoneId).Count()),
                Zone = item.Name,
            }).ToList();
           

        }

        public int GetNumberZones()
        {
            return _datagetter.QueryNumberZones();
        }
        public int GetNumberRoberys()
        {
            return _datagetter.QueryNumberRoberys();
        }


        public int GetNumberSensores()
        {
            return _datagetter.QueryNumberSensores();
        }


    }
}
