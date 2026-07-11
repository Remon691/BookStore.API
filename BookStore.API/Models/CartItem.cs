using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CartItem
{
    public int Id { get; set; }

    [Required]
    public int CartId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Range(1, 100)]
    public int Quantity { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(CartId))]
    public Cart Cart { get; set; } = null!;

    [ForeignKey(nameof(BookId))]
    public Book Book { get; set; } = null!;
}