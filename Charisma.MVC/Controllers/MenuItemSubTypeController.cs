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
            var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, id);
            return View(model);
        }

        // GET: MenuItemSubType/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(MenuItemController.Index), "MenuItem", new { id = id });
        }

        // GET: MenuItemSubType/Create
        public ActionResult Create(int ownerId)
        {
            var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, ownerId);
            return View(model);
        }

        // POST: MenuItemSubType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection col, int ownerId)
        {
            try
            {
                var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, ownerId);

                var obj = new MenuItemSubType()
                {
                    Name = col["ActiveSubType.Name"],
                    Description = col["ActiveSubType.Description"]
                };

                model.Owner.Members.Add(obj);
                repository.Update(model.Owner);
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
            var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, id, ownerId);
            return View(model);
        }

        // POST: MenuItemSubType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int ownerId, IFormCollection collection)
        {
            try
            {
                var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, id, ownerId);
                
                // Modify
                model.ActiveSubType.Name = collection["ActiveSubType.Name"];
                model.ActiveSubType.Description = collection["ActiveSubType.Description"];

                // Update table
                repository.Update(model.Owner);

                return RedirectToAction(nameof(Index), new { id = ownerId });
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItemSubType/Delete/5
        public ActionResult Delete(int id, int ownerId)
        {
            var model = new GenericMenuModel<MenuItemType, MenuItemSubType, MenuItem>(repository, id, ownerId);

            // Remove subtype from the type and delete
            model.SubTypes.Remove(model.ActiveSubType);
            repository.Update(model.Owner);

            return RedirectToAction(nameof(Index), new { id = ownerId });
        }
    }
}