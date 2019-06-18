using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.VehicleViewBags
{
	public class UpdateVehicleViewBag
	{
		public VehicleResponseDTO VehicleResponseDTO { get; set; }
		public VehicleRequestDTO VehicleRequestDTO { get; set; }
		public IEnumerable<BrandResponseDTO> Brands { get; set; }
		public IEnumerable<VehicleTypeResponseDTO> VehTypes { get; set; }
	}
}
