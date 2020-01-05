using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charisma.Core.Data;
using Charisma.Core.Model.Menu;
using Charisma.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var model = repository.GetFull(nameof(MenuItemType.SubTypes)).Where(c => c.Id == id).FirstOrDefault()?.SubTypes;
            TempData["OwnerId"] = id;
            return View(model);
        }

        // GET: MenuItemSubType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MenuItemSubType/Create
        public ActionResult Create(int ownerId)
        {
            TempData["OwnerId"] = ownerId;
            return View();
        }

        // POST: MenuItemSubType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection col, int ownerId)
        {
            try
            {
                var obj = new MenuItemSubType()
                {
                    Name = col["Name"],
                    Description = col["Description"]
                };
                var owner = repository.GetFull("SubTypes").Where(c => c.Id == ownerId).FirstOrDefault();
                owner.SubTypes.Add(obj);
                repository.Update(owner);
                return RedirectToAction(nameof(Index),new { id = ownerId });
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: MenuItemSubType/Edit/5
        public ActionResult Edit(int id, int ownerId)
        {
            return View();
        }

        // POST: MenuItemSubType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int ownerId, IFormCollection collection)
        {
            try
            {

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