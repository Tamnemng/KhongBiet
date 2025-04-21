using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; } = string.Empty;

        public string? Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; } = string.Empty;

        public bool GiftWrap { get; set; }
    }
}