using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.RoleCommands;
using Application.Commands.UserCommands;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
		private IGetUsersCommand _getUsers;
		private IGetSingleUserCommand _getSingleUser;
		private IInsertUserCommand _insertUser;
		private IUpdateUserCommand _updateUser;
		private IDeleteUserCommand _deleteUser;

		private IGetRoleCommand _getRoles;
		public UsersController(IGetUsersCommand getUsers, IGetSingleUserCommand getSingleUser, IInsertUserCommand insertUser, IUpdateUserCommand updateUser, IDeleteUserCommand deleteUser, IGetRoleCommand getRoles)
		{
			_getUsers = getUsers;
			_getSingleUser = getSingleUser;
			_insertUser = insertUser;
			_updateUser = updateUser;
			_deleteUser = deleteUser;
			_getRoles = getRoles;
		}
		// GET: Users
		public ActionResult Index([FromQuery] UserSearch search)
        {
			try
			{
				var users = _getUsers.Execute(search);
				return View(users);
			}
			catch(Exception)
			{
				return StatusCode(500, "Server error");
			}
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
			try
			{
				var user = _getSingleUser.Execute(id);
				return View(user);
			}
			catch (Exception)
			{
				return StatusCode(500, "Server error");
			}
		}

        // GET: Users/Create
        public ActionResult Create()
        {
			var viewbag = new UserCreateViewBag();
			viewbag.Roles = _getRoles.Execute(new RoleSearch { Keyword = null });
            return View(viewbag);
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateViewBag collection)
        {

			if (!ModelState.IsValid)
				return View();
			try
			{
				// TODO: Add insert logic here
				_insertUser.Execute(collection.UserDTO);
				return RedirectToAction(nameof(Index));
			}
			catch (EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch(EntityExistsException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			var viewbag = new UserCreateViewBag();
			viewbag.Roles = _getRoles.Execute(new RoleSearch { Keyword = null });
			return View(viewbag);
		}

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
			try
			{
				UserUpdateViewBag viewbag = new UserUpdateViewBag();
				viewbag.UserResponseDTO = _getSingleUser.Execute(id);
				viewbag.Roles = _getRoles.Execute(new RoleSearch());
				return View(viewbag);
			}
			catch (EntityNotFoundException)
			{
				return RedirectToAction("index");
			}
			catch (Exception)
			{
				return RedirectToAction(nameof(Index));
			}
		}

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserUpdateViewBag collection)
        {
			if (!ModelState.IsValid)
				return View();
			try
			{
				// TODO: Add update logic here
				_updateUser.Execute(id, collection.UserDTO);
				return RedirectToAction(nameof(Index));
			}
			catch(EntityExistsException e)
			{
				TempData["error"] = e.Message;
			}
			catch(EntityNotFoundException e)
			{
				TempData["error"] = e.Message;
			}
			catch (Exception)
			{
				TempData["error"] = "Server error";
			}
			return RedirectToAction(nameof(Edit));
		}

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
			try
			{
				var user = _getSingleUser.Execute(id);
				return View(user);
			}
			catch(EntityNotFoundException)
			{
				return RedirectToAction(nameof(Index));
			}
			catch (Exception)
			{
				return RedirectToAction(nameof(Index));
			}

		}

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				_deleteUser.Execute(id);
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
			var user = _getSingleUser.Execute(id);
			return View(user);
        }
    }
}