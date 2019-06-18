using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
    public class Vehicle : BaseEntity
    {
        public string Model { get; set; }
        public double FuelTankCapacity { get; set; }
        public double CostPerDay { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
		public bool Automatic { get; set; }
		public string Color { get; set; }
        public bool Rented { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
