﻿using SimulatorBusiness.DTO;
using SimulatorBusiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorService
{
    public class SimExecuter
    {
        private readonly HttpClient _client;
        private readonly string _url;
        private readonly int _numOfCars;
        private readonly int _numOfZones;
        public IDataBaseFlusher _flusher { get; set; }

        private List<Zone> _zones;
        private List<Car> _cars;
        private List<ZoneSensor> _sensors;
        private List<AirSensor> _airSensors;

        private Random _rand = new Random();


        public SimExecuter(IDataBaseFlusher flusher, bool createDB)
        {
            _client = new HttpClient();
            _url = "https://localhost:5001";
            _numOfCars = 15000;
            _numOfZones = 5;

            _zones = CreateZoneList();
            _cars = CreateCarList();
            _sensors = CreateSensorList();
            _airSensors = CreateAirSensorList();

            if (createDB)
            {
                flusher.PurgeDataBase();
                flusher.CreateDataBase(_zones, _cars, _sensors, _airSensors);
            }
        }

        /// <summary>
        /// This method simulates trafic of the city of the simulator.
        /// </summary>
        public void CallAPI()
        {
            var carMovedCount = 0;

            //Parallel.ForEach(_cars, async car =>
            //{
            foreach (var car in _cars)
            {

                if (_rand.NextDouble() < 0.021)
                {
                    carMovedCount += 1;

                    var values = new List<long>();

                    var zoneIndex = _zones.IndexOf(car._zone);
                    zoneIndex += _rand.NextDouble() >= 0.5 ? -1 : 1;
                    if (zoneIndex < 0) zoneIndex = 2;
                    if (zoneIndex >= _zones.Count) zoneIndex = _zones.Count - 2;

                    var zonesensors = _zones[zoneIndex].zoneSensors;

                    var sensor = zonesensors[_rand.Next(0, zonesensors.Count)];

                    values.Add(zoneIndex);
                    values.Add(sensor.Id);
                    values.Add(car._rfid);

                    //await RegisteZonePassAsync(values);
                    RegisteZonePassAsync(values).GetAwaiter().GetResult();

                    car._zone = _zones[zoneIndex];

                    Console.WriteLine($"car {car._rfid}, passed to zone {zoneIndex}, detected by the sensor {sensor.Id}");
                }

            }
            //});

            Console.WriteLine($"Number of cars moved: {carMovedCount}");

            Parallel.ForEach(_airSensors, async airSensor =>
            {
                if (_rand.NextDouble() < 0.50)
                {
                    var values = new List<long>
                    {
                        airSensor.AtachedZone.ZoneID,
                        airSensor.Id
                    };

                    var airValues = new List<double>
                    {
                        _rand.NextDouble() * 100, // co2
                        _rand.NextDouble() * 10,  // co
                        _rand.NextDouble() * 2,   // hc
                        _rand.NextDouble() * 15,  // rcho
                        _rand.NextDouble() * 4,   // nox
                        _rand.NextDouble() * 3,   // sox
                        _rand.NextDouble() * 6    // mp
                    };

                    await RegisterAirAsync(values, airValues);

                    Console.WriteLine($"Sensor {airSensor.Id}, registered atmosphere quality for zone {airSensor.AtachedZone.ZoneID}");
                }
            });
            Console.WriteLine($"Finished Call API");
        }

        private async Task RegisteZonePassAsync(List<long> values)
        {
            try
            {
                StringBuilder stringer = new StringBuilder($"{_url}/zone/traffic/");
                stringer.AppendJoin('/', values);


                HttpResponseMessage response = await _client.GetAsync(stringer.ToString());

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await _client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private async Task RegisterAirAsync(List<long> values, List<double> airValues)
        {
            try
            {
                StringBuilder stringer = new StringBuilder($"{_url}/zone/air/");
                stringer.AppendJoin('/', values);
                stringer.Append($"?co2={airValues[0]}");
                stringer.Append($"&co={airValues[1]}");
                stringer.Append($"&hc={airValues[2]}");
                stringer.Append($"&rcho={airValues[3]}");
                stringer.Append($"&nox={airValues[4]}");
                stringer.Append($"&sox={airValues[5]}");
                stringer.Append($"&mp={airValues[6]}");

                HttpResponseMessage response = await _client.GetAsync(stringer.ToString());

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await _client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        /// <summary>
        /// Creates Zones for the purpose of simulation.
        /// </summary>
        /// <returns>List of <see cref="Zone"/></returns>
        private List<Zone> CreateZoneList()
        {
            var zoneList = new List<Zone>();

            for (int i = 0; i < _numOfZones; i++) zoneList.Add(new Zone(i));

            return zoneList;
        }

        /// <summary>
        /// Creates Cars for the purpose of simulation.
        /// </summary>
        /// <returns>List of <see cref="Car"/></returns>
        private List<Car> CreateCarList()
        {
            var carList = new List<Car>();

            for (int i = 0; i < _numOfCars; i++) carList.Add(new Car(i, _zones[_rand.Next(0, _zones.Count)]));

            return carList;
        }

        /// <summary>
        /// Creates zone sensors for the purpose of simulation.
        /// </summary>
        /// <returns>List of <see cref="ZoneSensor"/></returns>
        private List<ZoneSensor> CreateSensorList()
        {
            var sensorList = new List<ZoneSensor>();

            for (int i = 0; i < 100; i++)
            {
                Zone zone = _zones[_rand.Next(0, _zones.Count)];
                var sensor = new ZoneSensor(i, zone);

                sensorList.Add(sensor);
                zone.zoneSensors.Add(sensor);
            }

            return sensorList;
        }


        /// <summary>
        /// Creates air sensors for the purpose of simulation.
        /// </summary>
        /// <returns>List of <see cref="AirSensor"/></returns>
        private List<AirSensor> CreateAirSensorList()
        {
            var sensorList = new List<AirSensor>();

            for (int i = 0; i < 100; i++)
            {
                Zone zone = _zones[_rand.Next(0, _zones.Count)];
                var sensor = new AirSensor(i, zone);

                sensorList.Add(sensor);
                zone.airSensors.Add(sensor);
            }

            return sensorList;
        }
    }
}
