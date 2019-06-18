using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.ResponseDTO
{
    public class BrandVehicleResponseDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double FuelTankCapacity { get; set; }
        public double CostPerHour { get; set; }
        public string VehicleType { get; set; }
		public bool Automatic { get; set; }
		public bool Rented { get; set; }
        public string Color { get; set; }

    }
}
