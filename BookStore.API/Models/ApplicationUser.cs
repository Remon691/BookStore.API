using Microsoft.AspNetCore.Identity;
using Stripe;
using Stripe.Climate;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class ApplicationUser :IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Cart? Cart { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();




    }
}
