﻿// <auto-generated />
using System;
using Garage3._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage3._0.Migrations
{
    [DbContext(typeof(Garage3_0Context))]
    [Migration("20240505135721_updatedParkingEntity")]
    partial class updatedParkingEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage3._0.Entites.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Membership")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Garage3._0.Entites.Ownership", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VehicleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MemberId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Ownerships");
                });

            modelBuilder.Entity("Garage3._0.Entites.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnershipMemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OwnershipVehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ParkingLotNumber")
                        .HasColumnType("int");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnershipMemberId", "OwnershipVehicleId");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("Garage3._0.Entites.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnershipMemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OwnershipVehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("TotParkingTime")
                        .HasColumnType("time");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnershipMemberId", "OwnershipVehicleId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("Garage3._0.Entites.Vehicle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Garage3._0.Entites.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumWheels")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("Garage3._0.Entites.Ownership", b =>
                {
                    b.HasOne("Garage3._0.Entites.Member", "Member")
                        .WithMany("Ownerships")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage3._0.Entites.Vehicle", "Vehicle")
                        .WithMany("Ownerships")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Garage3._0.Entites.Parking", b =>
                {
                    b.HasOne("Garage3._0.Entites.Ownership", "Ownership")
                        .WithMany("Parkings")
                        .HasForeignKey("OwnershipMemberId", "OwnershipVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ownership");
                });

            modelBuilder.Entity("Garage3._0.Entites.Receipt", b =>
                {
                    b.HasOne("Garage3._0.Entites.Ownership", "Ownership")
                        .WithMany("Receipts")
                        .HasForeignKey("OwnershipMemberId", "OwnershipVehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ownership");
                });

            modelBuilder.Entity("Garage3._0.Entites.VehicleType", b =>
                {
                    b.HasOne("Garage3._0.Entites.Vehicle", "Vehicle")
                        .WithOne("VehicleType")
                        .HasForeignKey("Garage3._0.Entites.VehicleType", "VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Garage3._0.Entites.Member", b =>
                {
                    b.Navigation("Ownerships");
                });

            modelBuilder.Entity("Garage3._0.Entites.Ownership", b =>
                {
                    b.Navigation("Parkings");

                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("Garage3._0.Entites.Vehicle", b =>
                {
                    b.Navigation("Ownerships");

                    b.Navigation("VehicleType")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
