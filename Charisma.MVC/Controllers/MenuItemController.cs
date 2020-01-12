using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charisma.Core.Data;
using Charisma.Core.Model.Menu;
using Charisma.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.MVC.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IRepository<MenuItemSubType> repository;

        public MenuItemController(IRepository<MenuItemSubType> repository)
        {
            this.repository = repository;
        }

        // GET: MenuItem
        public ActionResult Index(int id)
        {
            var model = new GenericMenuModel<MenuItemSubType, MenuItem, Ingredient>(repository, id);
            return View(model);
        }

        // GET: MenuItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuItem/Create
        public ActionResult Create(int ownerId)
        {
            var model = new GenericMenuModel<MenuItemSubType, MenuItem, Ingredient>(repository, ownerId);
            return View(model);
        }

        // POST: MenuItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuItem/Delete/5
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