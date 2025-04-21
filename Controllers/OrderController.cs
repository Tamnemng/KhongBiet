using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private Cart cart;

        public OrderController(Cart cartService)
        {
            cart = cartService;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                // Here you would typically save the order to the database
                cart.Clear();
                return View("Completed", order);
            }
            else
            {
                return View(order);
            }
        }
    }
}