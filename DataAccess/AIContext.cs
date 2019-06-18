using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataAccessModels;
using EFDataAccess.Configurations;

namespace EFDataAccess
{
    public class AIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ExtraAddon> ExtraAddons { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<RentStatus> RentStatus { get; set; }
		public DbSet<Rent> Rents { get; set; }
		public DbSet<RentExtraAddon> RentExtraAddons { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6DP2BHT\SQLEXPRESS;Initial Catalog=AIDataBase;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ExtraAddonConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new RentExtraAddonConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 8,
                Name = "Default group"
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 8,
                FirstName = "Predrag",
                LastName = "Crnogorac",
                Username = "admin",
				Password = "admin",
                RoleId = 8
            });
            modelBuilder.Entity<Brand>()
                .HasData(new Brand
                {
                    Id = 8,
                    Name = "Default brand"
                });
            modelBuilder.Entity<VehicleType>()
                .HasData(new VehicleType
                {
                    Id = 8,
                    Name = "Default type"
                });
            modelBuilder.Entity<Vehicle>()
                .HasData(new Vehicle
                {
                    Id = 8,
                    Model = "Default vehicle",
                    FuelTankCapacity = 40,
                    CostPerDay = 20,
                    BrandId = 8,
                    VehicleTypeId = 8,					
                    Color = "Blue"
                });
            modelBuilder.Entity<ExtraAddon>()
                .HasData(new ExtraAddon
                {
                    Id = 8,
                    Name = "Default add-on",
                    Price = 20
                });
			modelBuilder.Entity<Location>()
				.HasData(new Location
				{
					Id = 8,
					Adress = "Default location",
					Price = 10
				});
			modelBuilder.Entity<Customer>()
				.HasData(new Customer
				{
					Id = 8,
					FirstName = "Predrag",
					LastName = "Crnogorac",
					Email = "pbcrnogorac@gmail.com",
					PhoneNumber = "063/5551112",
					Birthday = new DateTime(1992, 6, 21)
				});
			modelBuilder.Entity<RentStatus>()
				.HasData(new RentStatus
				{
					Id = 8,
					Name = "Default stats"
				});
			modelBuilder.Entity<RentExtraAddon>()
				.HasData(new RentExtraAddon
				{
					RentId = 8,
					ExtraAddonId = 8,
					Price = 20
				});
			modelBuilder.Entity<Rent>()
				.HasData(new Rent
				{
					Id = 8,
					CustomerId = 8,
					UserId = 12,
					StatusId = 8,
					VehicleId = 8,
					LocationId = 8,
					DropLocationId = 8,
					FirstName = "Predrag",
					LastName = "Crnogorac",
					Email = "pbcrnogorac@gmail.com",
					PickDate = DateTime.Now,
					DropDate = DateTime.Now,
					PickAdress = "Svetolika Rankovica 2a",
					DropAdress = "Svetolika Randovica 2a",
					VehicleCostPerDay = 20,
					TotallPrice = 40
				});
        }
    }
}
