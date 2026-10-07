using Microsoft.AspNetCore.Mvc;
using Olivan_Midterm_Store.Data;
using Olivan_Midterm_Store.Models;


namespace Olivan_Midterm_Store.Controllers

{

    public class CartController : Controller

    {

        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db) { _db = db; }

 

        // shows the list

        public IActionResult Index()

        {

            var cart = _db.Cart_Items.ToList();

            return View(cart);

        }

        // EDIT - show the edit form
        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return RedirectToAction("Index");
            return View(product);
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
    }
}