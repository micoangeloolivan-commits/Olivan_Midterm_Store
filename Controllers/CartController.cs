using Microsoft.AspNetCore.Mvc;
using Olivan_Midterm_Store.Data;
using Olivan_Midterm_Store.Models;


namespace Olivan_Midterm_Store.Controllers

{

    public class CartController : Controller

    {

        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db) { _db = db; }


        // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var cart = _db.Cart_Items.Find(id);
            if (cart == null) return RedirectToAction("Index");
            return View(cart);
        }

        // EDIT - save the changes
        [HttpPost]
        public IActionResult Edit(CartItem cart)
        {
            _db.Cart_Items.Update(cart);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE - remove the product
        public IActionResult Delete(int id)
        {
            var cart = _db.Cart_Items.Find(id);
            if (cart != null)
            {
                _db.Cart_Items.Remove(cart);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int id)
        {
        var product = _db.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        var cartItem = new CartItem
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Price = product.Price,
            Quantity = 1
        };

        _db.Cart_Items.Add(cartItem);
        _db.SaveChanges();

        return RedirectToAction("Index");
        }

        public IActionResult Index(string searchString)
        {
        var cart = _db.Cart_Items.AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            cart = cart.Where(p => p.ProductName.ToLower().Contains(searchString));
        }

        ViewData["searchString"] = searchString;
        return View(cart.ToList());
        }

    }
}