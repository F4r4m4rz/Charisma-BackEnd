using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charisma.Core.Data;
using Charisma.Core.Model.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.MVC.Controllers
{
    public class MenuItemTypeController : Controller
    {
        private readonly IRepository<MenuItemType> repository;

        public MenuItemTypeController(IRepository<MenuItemType> repository)
        {
            this.repository = repository;
        }

        // GET: Menu
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            var model = repository.Get(id);
            return RedirectToAction(nameof(MenuItemSubTypeController.Index), "MenuItemSubType", model);
            //return View(model);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItemType obj)
        {
            try
            {
                repository.Add(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Get(id);
            return View(model);
        }

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuItemType obj)
        {
            try
            {
                repository.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}