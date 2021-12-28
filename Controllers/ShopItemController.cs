using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Repositories;
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

        private readonly IRepository<ShopItemModel> _shopItemRepository;

        public ShopItemController
            (ShopItemService shopItemService, ShopService shopService, TagService tagService, IRepository<ShopItemModel> shopItemRepository)
        {
            _shopItemService = shopItemService;
            _shopService = shopService;
            _tagService = tagService;

            _shopItemRepository = shopItemRepository;
        }

        // GET: ShopItemController
        public ActionResult Index()
        {
            //var shopItems = _shopItemService.GetAll();
            var shopItems = _shopItemRepository.GetAll();

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
                _shopItemRepository.Add(shopItemView.ShopItem);
                _shopItemRepository.SaveChanges();

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
                _shopItemRepository.Update(shopItemView.ShopItem);
                _shopItemRepository.SaveChanges();

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
            _shopItemRepository.Delete(id);
            _shopItemRepository.SaveChanges();

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