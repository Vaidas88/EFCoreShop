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
        private readonly TagService _tagService;

        public ShopItemController(ShopItemService shopItemService, ShopService shopService, TagService tagService)
        {
            _shopItemService = shopItemService;
            _shopService = shopService;
            _tagService = tagService;
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
            ShopItemViewModel shopItemView = new ShopItemViewModel();
            shopItemView.ShopItem = new ShopItemModel();
            shopItemView.Shops = _shopService.GetAll();
            shopItemView.Tags = _tagService.GetAll();

            return View(shopItemView);
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

            ShopItemViewModel shopItemView = new ShopItemViewModel();
            shopItemView.ShopItem = shopItem;
            shopItemView.Shops = _shopService.GetAll();
            shopItemView.Tags = _tagService.GetAll();

            return View(shopItemView);
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {
            ShopItemViewModel shopItemView = new ShopItemViewModel();
            shopItemView.ShopItem = _shopItemService.GetSingle(id);
            shopItemView.Shops = _shopService.GetAll();
            shopItemView.Tags = _tagService.GetAll();

            return View(shopItemView);
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

            ShopItemViewModel shopItemView = new ShopItemViewModel();
            shopItemView.ShopItem = shopItem;
            shopItemView.Shops = _shopService.GetAll();
            shopItemView.Tags = _tagService.GetAll();

            return View(shopItemView);
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopItemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}