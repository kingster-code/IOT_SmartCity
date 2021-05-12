using IOT_Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Data.Data
{
    public class SmartCityZoneContext : DbContext
    {
        public DbSet<AtmData> AtmosphereData { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleRoberyData> VehicleRoberies { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<ZoneAreaData> ZoneAreas { get; set; }
        public DbSet<ZoneParkingData> ZoneParkingRegister { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:/Users/danny/source/repos/IOT_API/IOT_Data/IoTDB.mdf;Integrated Security=True");
        }
    }
}
