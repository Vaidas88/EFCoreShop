using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using ShopApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: ShopItemController
        public ActionResult Index()
        {
            List<ShopModel> shops = _shopService.GetAll();

            return View(shops);
        }

        // GET: ShopItemController/Create
        public ActionResult Create()
        {
            ShopModel shop = new ShopModel();

            return View(shop);
        }

        // POST: ShopItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopModel shop)
        {
            if (ModelState.IsValid)
            {
                _shopService.Create(shop);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(shop);
            }
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {
            ShopModel shop = _shopService.GetSingle(id);

            return View(shop);
        }

        // POST: ShopItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopModel shop)
        {
            if (ModelState.IsValid)
            {
                _shopService.Edit(shop);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(shop);
            }
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
