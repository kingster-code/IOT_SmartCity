﻿// <auto-generated />
using System;
using IOT_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IOT_Data.Migrations
{
    [DbContext(typeof(SmartCityZoneContext))]
    partial class SmartCityZoneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("IOT_Data.Models.AtmData", b =>
                {
                    b.Property<int>("AtmreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CO")
                        .HasColumnType("REAL");

                    b.Property<double>("CO2")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("HC")
                        .HasColumnType("REAL");

                    b.Property<double>("MP")
                        .HasColumnType("REAL");

                    b.Property<double>("NOx")
                        .HasColumnType("REAL");

                    b.Property<double>("Rcho")
                        .HasColumnType("REAL");

                    b.Property<double>("SOx")
                        .HasColumnType("REAL");

                    b.Property<int?>("SensorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtmreadId");

                    b.HasIndex("SensorId");

                    b.ToTable("AtmosphereData");
                });

            modelBuilder.Entity("IOT_Data.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SensorId");

                    b.HasIndex("TypeId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("IOT_Data.Models.SensorType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TypeId");

                    b.ToTable("SensorTypes");
                });

            modelBuilder.Entity("IOT_Data.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Operational")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("IOT_Data.Models.VehicleRoberyData", b =>
                {
                    b.Property<int>("VehicleRoberyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Resolved")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehicleRoberyId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("ZoneId");

                    b.ToTable("VehicleRoberies");
                });

            modelBuilder.Entity("IOT_Data.Models.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ZoneId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneAreaData", b =>
                {
                    b.Property<int>("ZoneAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ZoneAreaId");

                    b.HasIndex("SensorId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ZoneAreas");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneParkingData", b =>
                {
                    b.Property<int>("ZoneParkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SensorId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ZoneParkingId");

                    b.HasIndex("SensorId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ZoneParkingRegister");
                });

            modelBuilder.Entity("IOT_Data.Models.AtmData", b =>
                {
                    b.HasOne("IOT_Data.Models.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("IOT_Data.Models.Sensor", b =>
                {
                    b.HasOne("IOT_Data.Models.SensorType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("IOT_Data.Models.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId");

                    b.Navigation("Type");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("IOT_Data.Models.VehicleRoberyData", b =>
                {
                    b.HasOne("IOT_Data.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.HasOne("IOT_Data.Models.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId");

                    b.Navigation("Vehicle");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneAreaData", b =>
                {
                    b.HasOne("IOT_Data.Models.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId");

                    b.HasOne("IOT_Data.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Sensor");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneParkingData", b =>
                {
                    b.HasOne("IOT_Data.Models.Sensor", "Sensor")
                        .WithMany()
                        .HasForeignKey("SensorId");

                    b.HasOne("IOT_Data.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Sensor");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
