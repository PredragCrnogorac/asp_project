using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application.Commands.LocationCommands;
using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly IGetLocationsCommand _getLocations;
		private readonly IGetSingleLocationCommand _getSingleLocation;
		private readonly IInsertLocationCommand _insertLocation;
		private readonly IDeleteLocationCommand _deleteLocation;
		private readonly IUpdateLocationCommand _updateLocation;
		public LocationsController(IGetLocationsCommand getLocations, IGetSingleLocationCommand getSingleLocation, IInsertLocationCommand insertLocation, IDeleteLocationCommand deleteLocation, IUpdateLocationCommand updateLocation)
		{
			_getLocations = getLocations;
			_getSingleLocation = getSingleLocation;
			_insertLocation = insertLocation;
			_deleteLocation = deleteLocation;
			_updateLocation = updateLocation;
		}
		// GET: api/Locations
		[HttpGet]
		public ActionResult<IEnumerable<LocationResponseDTO>> Get([FromQuery] LocationSearch search)
		{
			try
			{
				var transmissions = _getLocations.Execute(search);
				return Ok(transmissions);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

		// GET: api/Locations/5
		[HttpGet("{id}")]
		public ActionResult<LocationResponseDTO> Get(int id)
		{
			try
			{
				var transmission = _getSingleLocation.Execute(id);
				return Ok(transmission);
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

		// POST: api/Locations
		[HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<LocationResponseDTO> Post([FromBody] LocationRequestDTO value)
		{
			try
			{
				var transmission = _insertLocation.Execute(value);
				return Created("api/transmissions/" + transmission.Id, transmission);
			}
			catch (EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

		// PUT: api/Locations/5
		[HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] LocationRequestDTO value)
		{
			try
			{
				_updateLocation.Execute(id, value);
				return NoContent();
			}
			catch (EntityNotFoundException e)
			{
				return NotFound(e.Message);
			}
			catch (EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

		// DELETE: api/Locations/5
		[HttpDelete("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Delete(int id)
		{
			try
			{
				_deleteLocation.Execute(id);
				return NoContent();
			}
			catch (EntityExistsException e)
			{
				return Conflict(e.Message);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}
	}
}
