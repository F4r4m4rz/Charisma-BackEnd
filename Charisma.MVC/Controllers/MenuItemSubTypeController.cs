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
    public class MenuItemSubTypeController : Controller
    {
        private readonly IRepository<MenuItemType> repository;

        public MenuItemSubTypeController(IRepository<MenuItemType> repository)
        {
            this.repository = repository;
        }

        // GET: MenuItemSubType
        public ActionResult Index(int id)
        {
            var model = repository.GetFull(nameof(MenuItemType.SubTypes)).Where(c => c.Id == id).FirstOrDefault();
            ViewData.Add("OwnerId", id);
            return View(model.SubTypes);
        }

        // GET: MenuItemSubType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuItemSubType/Create
        public ActionResult Create(int id)
        {
            ViewData.Add("OwnerId", id);
            return View();
        }

        // POST: MenuItemSubType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuItemSubType obj, int id)
        {
            try
            {
                var owner = repository.GetFull("SubTypes").Where(c => c.Id == id).FirstOrDefault();
                if (owner.SubTypes == null)
                    owner.SubTypes = new List<MenuItemSubType>();
                owner.SubTypes.Add(obj);
                repository.Update(owner);
                return RedirectToAction(nameof(Index), owner.Id);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: MenuItemSubType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuItemSubType/Edit/5
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

        // GET: MenuItemSubType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MenuItemSubType/Delete/5
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