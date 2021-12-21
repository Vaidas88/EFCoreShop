using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using ShopApp.Services;

namespace ShopApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopItemService _shopItemService;
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService, ShopItemService shopItemService)
        {
            _shopService = shopService;
            _shopItemService = shopItemService;
        }

        // GET: ShopItemController
        public ActionResult Index()
        {
            var shops = _shopService.GetAll();

            return View(shops);
        }

        // GET: ShopItemController/Create
        public ActionResult Create()
        {
            var shop = new ShopModel();

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

            return View(shop);
        }

        // GET: ShopItemController/Edit/5
        public ActionResult Edit(int id)
        {
            var shop = _shopService.GetSingle(id);

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

            return View(shop);
        }

        // GET: ShopItemController/Delete/5
        public ActionResult Delete(int id)
        {
            _shopService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult ViewShop(int id)
        {
            ViewData["ShopTitle"] = _shopService.GetSingle(id).Name;
            var shopItems = _shopItemService.GetAllByShop(id);

            return View(shopItems);
        }
    }
}