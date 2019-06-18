using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.RequestDTO
{
    public class VehicleRequestDTO
    {
        public string Model { get; set; }
        public double FuelTankCapacity { get; set; }
        public double CostPerDay { get; set; }
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
		public string Color { get; set; }
		public bool? Automatic { get; set; }
	}
}
