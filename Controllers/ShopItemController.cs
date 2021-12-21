﻿using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Services;
using ShopApp.ViewModels;

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
            var shopItems = _shopItemService.GetAll();

            return View(shopItems);
        }

        // GET: ShopItemController/Create
        public ActionResult Create()
        {
            var shopItem = new ShopItemViewModel(new ShopItemModel(), _shopService.GetAll());

            return View(shopItem);
        }

        // POST: ShopItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopItemModel shopItem)
        {
            if (ModelState.IsValid)
            {
                _shopItemService.Create(shopItem);

                return RedirectToAction(nameof(Index));
            }

            return View(new ShopItemViewModel(shopItem, _shopService.GetAll()));
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {
            var shopItem = new ShopItemViewModel(_shopItemService.GetSingle(id), _shopService.GetAll());

            return View(shopItem);
        }

        // POST: ShopItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopItemModel shopItem)
        {
            if (ModelState.IsValid)
            {
                _shopItemService.Edit(shopItem);

                return RedirectToAction(nameof(Index));
            }

            return View(new ShopItemViewModel(shopItem, _shopService.GetAll()));
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopItemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}