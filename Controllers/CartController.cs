using Microsoft.AspNetCore.Mvc;
using SportStore.Infrastructure;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class CartController : Controller
    {
        private IStoreRepository repository;
        private Cart cart;

        public CartController(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public IActionResult Index(string returnUrl)
        {
            return View("Cart", new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public IActionResult AddToCart(long productId, string returnUrl)
        {
            Product? product = repository.GetProducts
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }

        public IActionResult RemoveFromCart(long productId, string returnUrl)
        {
            Product? product = repository.GetProducts
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }

        // Update quantity of an item in cart
        public IActionResult UpdateQuantity(long productId, int quantity, string returnUrl)
        {
            Product? product = repository.GetProducts
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                // First remove existing line
                cart.RemoveLine(product);
                
                // Then add with new quantity if quantity > 0
                if (quantity > 0)
                {
                    cart.AddItem(product, quantity);
                }
            }

            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
    }
}