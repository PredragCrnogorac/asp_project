using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.BrandCommands;
using Application.DTO.RequestDTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BrandsController : Controller
    {
		readonly IGetBrandsCommand _getBrands;
		readonly IGetSingleBrandCommand _getBrand;
		readonly IInsertBrandCommand _insertBrand;
		readonly IUpdateBrandCommand _updateBrand;
		public BrandsController(IGetBrandsCommand getBrands, IGetSingleBrandCommand getBrand, IInsertBrandCommand insertBrand, IUpdateBrandCommand updateBrand)
		{
			_getBrands = getBrands;
			_getBrand = getBrand;
			_insertBrand = insertBrand;
			_updateBrand = updateBrand;
		}
        // GET: Brands
        public ActionResult Index([FromQuery] BrandSearch search)
        {
			var brands = _getBrands.Execute(search);
            return View(brands);
        }

        // GET: Brands/Details/5
        public ActionResult Details(int id)
        {
			try
			{
				var brand = _getBrand.Execute(id);
				return View(brand);
			}
			catch(EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
				return View();
			}
        }

        // GET: Brands/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandRequestDTO value)
        {
			if (!ModelState.IsValid)
			{
				return View(value);
			}
            try
            {
				// TODO: Add insert logic here
				_insertBrand.Execute(value);
                return RedirectToAction(nameof(Index));
            }
			catch(EntityExistsException e)
			{
				TempData["error"] = e.Message; 
			}
            catch
            {
				TempData["error"] = "Server error";
                
            }
			return View();
		}

        // GET: Brands/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BrandRequestDTO collection)
        {
			if (!ModelState.IsValid)
				return View(collection);
            try
            {
				// TODO: Add update logic here
				_updateBrand.Execute(id, collection);
                return RedirectToAction(nameof(Index));
            }
			catch(EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (EntityExistsException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			return View();
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Brands/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}