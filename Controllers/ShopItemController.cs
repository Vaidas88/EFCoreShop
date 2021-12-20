using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Services;
using ShopApp.ViewModels;
using System.Collections.Generic;

namespace ShopApp.Controllers
{
    public class ShopItemController : Controller
    {
        private readonly ShopItemService _shopItemService;
        private readonly ShopService _shopService;

        public ShopItemController(ShopItemService shopItemService, ShopService shopService)
        {
            _shopItemService = shopItemService;
            _shopService = shopService;
        }

        // GET: ShopItemController
        public ActionResult Index()
        {
            List<ShopItemModel> shopItems = _shopItemService.GetAll();
            return View(shopItems);
        }

        // GET: ShopItemController/Create
        public ActionResult Create()
        {
            ShopItemViewModel shopItem = new ShopItemViewModel();
            shopItem.Shops = _shopService.GetAll();
            return View(shopItem);
        }

        // POST: ShopItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopItemModel shopItem)
        {
            try
            {
                _shopItemService.Create(shopItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {
            ShopItemViewModel shopItem = new ShopItemViewModel(_shopItemService.GetSingle(id));
            shopItem.Shops = _shopService.GetAll();

            return View(shopItem);
        }

        // POST: ShopItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopItemModel shopItem)
        {
            try
            {
                _shopItemService.Edit(shopItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
