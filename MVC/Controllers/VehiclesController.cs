using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.BrandCommands;
using Application.Commands.VehicleCommands;
using Application.Commands.VehicleTypeCommands;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.VehicleViewBags;

namespace MVC.Controllers
{
    public class VehiclesController : Controller
    {
		private readonly IInsertVehicleCommand _insertVehicle;
		private readonly IGetVehiclesCommand _getVehicles;
		private readonly IGetSIngleVehicleCommand _getSingleVehicles;
		private readonly IDeleteVehicleCommand _deleteVehicle;
		private readonly IUpdateVehicleCommand _updateVehicle;

		private readonly IGetVehicleTypesCommand _getVehTypes;
		private readonly IGetBrandsCommand _getBrands;
		public VehiclesController(IGetVehicleTypesCommand getVehTypes,IGetBrandsCommand getBrands,IInsertVehicleCommand insertVehicle, IGetVehiclesCommand getVehicles, IGetSIngleVehicleCommand getSIngleVehicle, IDeleteVehicleCommand deleteVehicle, IUpdateVehicleCommand updateVehicle)
		{
			_getVehTypes = getVehTypes;
			_getBrands = getBrands;
			_insertVehicle = insertVehicle;
			_getVehicles = getVehicles;
			_getSingleVehicles = getSIngleVehicle;
			_deleteVehicle = deleteVehicle;
			_updateVehicle = updateVehicle;
		}
		// GET: Vehicles
		public ActionResult Index()
        {
			try
			{
				var vehicles = _getVehicles.Execute(new VehicleSearch { Keyword = "" });
				return View(vehicles);
			}
			catch (Exception)
			{
				return View();
			}
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int id)
        {
			try
			{
				var vehicle = _getSingleVehicles.Execute(id);

				return View(vehicle);
			}
			catch(EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			return RedirectToAction(nameof(Index));
		}

        // GET: Vehicles/Create
        public ActionResult Create()
        {
			var insertBag = new InsertVehicleViewBag();
			insertBag.Brands =  _getBrands.Execute(new BrandSearch { Keyword = "" });
			insertBag.VehTypes =  _getVehTypes.Execute(new VehicleTypeSearch { Keyword = "" });
			return View(insertBag);
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InsertVehicleViewBag collection)
        {
            try
            {
				// TODO: Add insert logic here
				_insertVehicle.Execute(collection.VehicleRequestDTO);
                return RedirectToAction(nameof(Index));
            }
            catch(EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			return View();
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int id)
        {
			try
			{
				UpdateVehicleViewBag viewbag = new UpdateVehicleViewBag();
				viewbag.VehicleResponseDTO = _getSingleVehicles.Execute(id);
				viewbag.Brands = _getBrands.Execute(new BrandSearch { Keyword = "" });
				viewbag.VehTypes = _getVehTypes.Execute(new VehicleTypeSearch { Keyword = "" });
				var vehicle = _getSingleVehicles.Execute(id);

				return View(viewbag);
			}
			catch (Exception)
			{
				return RedirectToAction(nameof(Index));
			}
		}

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateVehicleViewBag collection)
        {
            try
            {
				// TODO: Add update logic here
				_updateVehicle.Execute(id, collection.VehicleRequestDTO);
                return RedirectToAction(nameof(Index));
            }
			catch (EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			return RedirectToAction(nameof(Index));
		}

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int id)
        {
			try
			{
				var veh = _getSingleVehicles.Execute(id);
				return View(veh);
			}
			catch (EntityNotFoundException e)
			{
				return RedirectToAction(nameof(Index));
			}
		}

        // POST: Vehicles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
			try
			{
				// TODO: Add delete logic here
				_deleteVehicle.Execute(id);
				return RedirectToAction(nameof(Index));
			}
			catch (EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (EntityExistsException)
			{
				TempData["error"] = "You can't delete vehicle which is being rented";
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			var veh = _getSingleVehicles.Execute(id);
			return View(veh);
		}
    }
}