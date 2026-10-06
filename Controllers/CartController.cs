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
    }
}