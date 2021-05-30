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
            optionsBuilder.UseSqlite("Data Source=C:/Users/danny/Desktop/UBI/Semestre 2/IOT/DBIOT/SmartCity.db;");
            //optionsBuilder.UseSqlite("Data Source= /Users/rodrigosaraiva/Desktop/IOT_SmartCity/DB/SmartCity.db");


        }
    }
}
