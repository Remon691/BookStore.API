using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class WishlistItem
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public int BookId { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; } = null!;
}