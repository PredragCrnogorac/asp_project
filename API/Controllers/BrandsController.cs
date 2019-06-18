using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Application;
using Application.Commands.BrandCommands;
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
    public class BrandsController : ControllerBase
    {
        private readonly IGetBrandsCommand _getBrands;
        private readonly IInsertBrandCommand _insertBrand;
        private readonly IGetSingleBrandCommand _getSingleBrand;
        private readonly IDeleteBrandCommand _deleteBrand;
        private readonly IUpdateBrandCommand _updateBrand;

		private readonly LoggedUser _user;
		public BrandsController(LoggedUser user, IGetBrandsCommand getBrands, IInsertBrandCommand insertBrand, IGetSingleBrandCommand getSingleBrand, IDeleteBrandCommand deleteBrand, IUpdateBrandCommand updateBrand)
        {
			_user = user;
			_getBrands = getBrands;
            _insertBrand = insertBrand;
            _getSingleBrand = getSingleBrand;
            _deleteBrand = deleteBrand;
            _updateBrand = updateBrand;
        }
        // GET: api/Brands

        [HttpGet]
        public ActionResult<IEnumerable<BrandResponseDTO>> Get([FromQuery] BrandSearch search)
        {
            var brands = _getBrands.Execute(search);
            return Ok(brands);
        }

        // GET: api/Brands/5
        [HttpGet("{id}", Name = "GetBrands")]
        public ActionResult<BrandResponseDTO> Get(int id)
        {
            try
            {
                var brand =_getSingleBrand.Execute(id);
                return Ok(brand);
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        // POST: api/Brands
        [HttpPost]
		[LoggedIn("Admin")]
		public ActionResult<BrandResponseDTO> Post([FromBody] BrandRequestDTO value)
        {
            try
            {
                var brand =_insertBrand.Execute(value);
                return Created("api/brands/" + brand.Id, brand);
            }
            catch(EntityExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        // PUT: api/Brands/5
        [HttpPut("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Put(int id, [FromBody] BrandRequestDTO value)
        {
            try
            {
                _updateBrand.Execute(id, value);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(EntityExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
		[LoggedIn("Admin")]
		public IActionResult Delete(int id)
        {
            try
            {
                _deleteBrand.Execute(id);
                return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }
    }
}
