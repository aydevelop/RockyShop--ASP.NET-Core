using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using Rocky.Utility;
using System.Collections.Generic;
using System.Linq;

namespace Rocky.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Env.SessionCart) != null && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Env.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(Env.SessionCart);
            }

            List<int> prodInCart = shoppingCartList.Select(i => i.ProductId).ToList();
            IEnumerable<Product> prodList = _db.Product.Where(u => prodInCart.Contains(u.Id)).ToList();

            return View(prodList);
        }

        public IActionResult Remove(int id)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Env.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(Env.SessionCart).Count() > 0)
            {
                //session exsits
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(Env.SessionCart);
            }

            shoppingCartList.Remove(shoppingCartList.FirstOrDefault(u => u.ProductId == id));
            HttpContext.Session.Set(Env.SessionCart, shoppingCartList);
            return RedirectToAction(nameof(Index));
        }
    }
}
