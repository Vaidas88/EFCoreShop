using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Services;
using ShopApp.ViewModels;
using System;
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
            ShopItemViewModel shopItemView = CreateShopItemView(new ShopItemModel());

            return View(shopItemView);
        }

        // POST: ShopItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopItemViewModel shopItemView)
        {
            if (ModelState.IsValid)
            {
                _shopItemService.Create(shopItemView.ShopItem);

                foreach (int tagId in shopItemView.SelectedTagIds)
                {
                    _tagService.AssignTagToShopItem(
                        new ShopItemTagModel()
                        {
                            TagId = tagId,
                            ShopItemId = shopItemView.ShopItem.Id
                        });
                }

                return RedirectToAction(nameof(Index));
            }

            shopItemView = CreateShopItemView(shopItemView.ShopItem);

            return View(shopItemView);
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {

            ShopItemViewModel shopItemView = CreateShopItemView(_shopItemService.GetSingle(id));

            return View(shopItemView);
        }

        // POST: ShopItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShopItemViewModel shopItemView)
        {
            if (ModelState.IsValid)
            {
                _shopItemService.Edit(shopItemView.ShopItem);
                _tagService.DeleteShopItemTags(shopItemView.ShopItem.Id);

                foreach (int tagId in shopItemView.SelectedTagIds)
                {
                    _tagService.AssignTagToShopItem(
                        new ShopItemTagModel()
                        {
                            TagId = tagId,
                            ShopItemId = shopItemView.ShopItem.Id
                        });
                }

                return RedirectToAction(nameof(Index));
            }

            shopItemView = CreateShopItemView(shopItemView.ShopItem);

            return View(shopItemView);
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopItemService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private ShopItemViewModel CreateShopItemView(ShopItemModel shopItem)
        {
            ShopItemViewModel shopItemView = new ShopItemViewModel();
            shopItemView.ShopItem = shopItem;
            shopItemView.Shops = _shopService.GetAll();
            shopItemView.Tags = _tagService.GetAll();

            return shopItemView;
        }
    }
}