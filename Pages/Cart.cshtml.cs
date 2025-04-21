using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportStore.Models;

namespace SportStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository repository;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        
        public IActionResult OnPost(string handler, long productId, string returnUrl)
        {
            Product? product = repository.GetProducts.FirstOrDefault(p => p.ProductID == productId);
            
            if (product != null)
            {
                if (handler == "Remove")
                {
                    Cart.RemoveLine(product);
                }
                else
                {
                    Cart.AddItem(product, 1);
                }
            }
            
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}