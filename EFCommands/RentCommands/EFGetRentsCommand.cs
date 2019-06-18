using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RentCommands;
using Application.DTO;
using Application.DTO.ResponseDTO;
using Application.DTO.ResponseDTO.RentResponseDTO;
using Application.Intefaces;
using Application.Searches.RentSearches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EFCommands.RentCommands
{
	public class EFGetRentsCommand : BaseEFCommand, IGetRentsCommand
	{
		public EFGetRentsCommand(AIContext context) : base(context)
		{
		}

		public PagedResponseDTO<RentResponseDTO> Execute(RentSearch request)
		{
			var query = AiContext.Rents
				.Where(x => x.IsDeleted == 0)
				.AsQueryable();
			if (request.Model != null)
				query = query
					.Where(x => x.Vehicle.Model.ToLower().Contains(request.Model.ToLower()));
			if (request.Username != null)
				query = query
					.Where(x => x.User.Username.ToLower().Contains(request.Username.ToLower()));
			if (request.Email != null)
				query = query
					.Where(x => x.Customer.Email.ToLower().Contains(request.Email.ToLower()));
			if (request.Brand != null)
				query = query
					.Where(x => x.Vehicle.Brand.Name.ToLower().Contains(request.Brand.ToLower()));
			/* Pagination
			* Current page is sent threw query string, if there is no value for it's default value is 1
			* Same goes for PerPage
			* Paged response coctains Current page, Totall pages and data in current page and sends it back threw API
			*/
			var totallCount = query.Count();
			var currentPage = request.CurrentPage.HasValue ? request.CurrentPage.GetValueOrDefault() : 1;
			var perPage = request.PerPage.HasValue ? request.PerPage.GetValueOrDefault() : 3;
			var pagesCount = (int)Math.Ceiling((double)totallCount / perPage);

			query = query.Skip((currentPage - 1) * perPage).Take(perPage);
			var response = new PagedResponseDTO<RentResponseDTO>
			{
				CurrentPage = currentPage,
				PageCount = pagesCount,
				TotallCount = totallCount,
				Data = query
				.Select(x => new RentResponseDTO
				{
					Id = x.Id,
					UserId = x.UserId,
					CustomerId = x.CustomerId,
					LocationId = x.LocationId,
					DropLocationId = x.DropLocationId,
					VehicleId = x.VehicleId,
					StatusId = x.StatusId,
					VehicleModel = x.Vehicle.Model,
					RentStatus = x.RentStatus.Name,
					VehicleCostPerDay = x.VehicleCostPerDay,
					FirstName = x.FirstName,
					LastName = x.LastName,
					Email = x.Email,
					TotallPrice = x.TotallPrice,
					PickDate = x.PickDate,
					DropDate = x.DropDate,
					PickAdress = x.PickAdress,
					DropAdress = x.DropAdress,
					RentExtraAddons = AiContext.RentExtraAddons
										.Where(re => re.RentId == x.Id)
										.Select(re => new RentExtraAddonResponseDTO
										{
											ExtraAddonId = re.ExtraAddonId,
											ExtraAddonName = re.ExtraAddon.Name,
											Price = re.ExtraAddon.Price
										})
				})
			};
			return response;
		}
	}
}
		