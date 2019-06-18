﻿// <auto-generated />
using System;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(AIContext))]
    [Migration("20190616142335_Removing max size of Email.Customer")]
    partial class RemovingmaxsizeofEmailCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessModels.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default brand"
                        });
                });

            modelBuilder.Entity("DataAccessModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(1992, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pbcrnogorac@gmail.com",
                            FirstName = "Predrag",
                            LastName = "Crnogorac",
                            PhoneNumber = "063/5551112"
                        });
                });

            modelBuilder.Entity("DataAccessModels.ExtraAddon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<double>("Price")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("ExtraAddons");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default add-on",
                            Price = 20.0
                        });
                });

            modelBuilder.Entity("DataAccessModels.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<double>("Price")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Adress = "Default location",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Price = 10.0
                        });
                });

            modelBuilder.Entity("DataAccessModels.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("CustomerId");

                    b.Property<string>("DropAdress");

                    b.Property<DateTime>("DropDate");

                    b.Property<int>("DropLocationId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName");

                    b.Property<int>("LocationId");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("PickAdress");

                    b.Property<DateTime>("PickDate");

                    b.Property<int>("StatusId");

                    b.Property<double>("TotallPrice");

                    b.Property<int>("UserId");

                    b.Property<double>("VehicleCostPerDay");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DropLocationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Rents");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 8,
                            DropAdress = "Svetolika Randovica 2a",
                            DropDate = new DateTime(2019, 6, 16, 16, 23, 33, 939, DateTimeKind.Local).AddTicks(8446),
                            DropLocationId = 8,
                            Email = "pbcrnogorac@gmail.com",
                            FirstName = "Predrag",
                            LastName = "Crnogorac",
                            LocationId = 8,
                            PickAdress = "Svetolika Rankovica 2a",
                            PickDate = new DateTime(2019, 6, 16, 16, 23, 33, 936, DateTimeKind.Local).AddTicks(6017),
                            StatusId = 8,
                            TotallPrice = 40.0,
                            UserId = 12,
                            VehicleCostPerDay = 20.0,
                            VehicleId = 8
                        });
                });

            modelBuilder.Entity("DataAccessModels.RentExtraAddon", b =>
                {
                    b.Property<int>("RentId");

                    b.Property<int>("ExtraAddonId");

                    b.Property<int>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<double>("Price");

                    b.HasKey("RentId", "ExtraAddonId");

                    b.HasIndex("ExtraAddonId");

                    b.ToTable("RentExtraAddons");

                    b.HasData(
                        new
                        {
                            RentId = 8,
                            ExtraAddonId = 8,
                            IsDeleted = 0,
                            Price = 20.0
                        });
                });

            modelBuilder.Entity("DataAccessModels.RentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("RentStatus");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default stats"
                        });
                });

            modelBuilder.Entity("DataAccessModels.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default group"
                        });
                });

            modelBuilder.Entity("DataAccessModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("8");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Predrag",
                            LastName = "Crnogorac",
                            Password = "admin",
                            RoleId = 8,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DataAccessModels.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Automatic")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("BrandId");

                    b.Property<string>("Color");

                    b.Property<double>("CostPerDay")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<double>("FuelTankCapacity")
                        .HasMaxLength(5);

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<bool>("Rented")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("VehicleTypeId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Automatic = false,
                            BrandId = 8,
                            Color = "Blue",
                            CostPerDay = 20.0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FuelTankCapacity = 40.0,
                            Model = "Default vehicle",
                            Rented = false,
                            VehicleTypeId = 8
                        });
                });

            modelBuilder.Entity("DataAccessModels.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<DateTime?>("ModifiedAt");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Default type"
                        });
                });

            modelBuilder.Entity("DataAccessModels.Rent", b =>
                {
                    b.HasOne("DataAccessModels.Customer", "Customer")
                        .WithMany("Rents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccessModels.Location", "DropLocation")
                        .WithMany()
                        .HasForeignKey("DropLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessModels.Location", "Location")
                        .WithMany("Rents")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccessModels.RentStatus", "RentStatus")
                        .WithMany("Rents")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccessModels.User", "User")
                        .WithMany("Rents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccessModels.Vehicle", "Vehicle")
                        .WithMany("Rents")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DataAccessModels.RentExtraAddon", b =>
                {
                    b.HasOne("DataAccessModels.ExtraAddon", "ExtraAddon")
                        .WithMany("RentExtraAddons")
                        .HasForeignKey("ExtraAddonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DataAccessModels.Rent", "Rent")
                        .WithMany("RentExtraAddons")
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DataAccessModels.User", b =>
                {
                    b.HasOne("DataAccessModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DataAccessModels.Vehicle", b =>
                {
                    b.HasOne("DataAccessModels.Brand", "Brand")
                        .WithMany("Vehicles")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessModels.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
