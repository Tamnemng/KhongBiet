using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportStore.Models;

namespace SportStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository repository;
        public Cart Cart { get; set; }
        public string ReTurnUrl { get; set; } = "/";
        
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        
        public void OnGet(string reTurnUrl)
        {
            ReTurnUrl = reTurnUrl ?? "/";
        }
        
        public IActionResult OnPost(long productId, string reTurnUrl)
        {
            Product? product = repository.GetProducts.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { reTurnUrl = reTurnUrl });
        }
        
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            // Fix: Get the product first to ensure it exists
            Product? product = repository.GetProducts.FirstOrDefault(p => p.ProductID == productId);
            
            if (product != null)
            {
                // Use the product object directly rather than trying to find it in the cart
                Cart.RemoveLine(product);
            }
            
            return RedirectToPage(new { reTurnUrl = returnUrl });
        }
    }
}