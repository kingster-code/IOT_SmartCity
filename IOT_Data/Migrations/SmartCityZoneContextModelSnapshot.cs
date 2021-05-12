﻿// <auto-generated />
using System;
using IOT_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IOT_Data.Models.AtmData", b =>
                {
                    b.Property<int>("AtmreadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CO")
                        .HasColumnType("float");

                    b.Property<double>("CO2")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("HC")
                        .HasColumnType("float");

                    b.Property<double>("MP")
                        .HasColumnType("float");

                    b.Property<double>("NOx")
                        .HasColumnType("float");

                    b.Property<double>("Rcho")
                        .HasColumnType("float");

                    b.Property<double>("SOx")
                        .HasColumnType("float");

                    b.Property<int?>("SensorId")
                        .HasColumnType("int");

                    b.HasKey("AtmreadId");

                    b.HasIndex("SensorId");

                    b.ToTable("AtmosphereData");
                });

            modelBuilder.Entity("IOT_Data.Models.Sensor", b =>
                {
                    b.Property<int>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("SensorId");

                    b.HasIndex("TypeId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("IOT_Data.Models.SensorType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SensorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("SensorTypes");
                });

            modelBuilder.Entity("IOT_Data.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Operational")
                        .HasColumnType("bit");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("IOT_Data.Models.VehicleRoberyData", b =>
                {
                    b.Property<int>("VehicleRoberyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Resolved")
                        .HasColumnType("bit");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("VehicleRoberyId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("ZoneId");

                    b.ToTable("VehicleRoberies");
                });

            modelBuilder.Entity("IOT_Data.Models.Zone", b =>
                {
                    b.Property<int>("ZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZoneId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneAreaData", b =>
                {
                    b.Property<int>("ZoneAreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SensorId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("ZoneAreaId");

                    b.HasIndex("SensorId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ZoneAreas");
                });

            modelBuilder.Entity("IOT_Data.Models.ZoneParkingData", b =>
                {
                    b.Property<int>("ZoneParkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("SensorId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

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