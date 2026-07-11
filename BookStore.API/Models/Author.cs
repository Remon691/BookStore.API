using System.ComponentModel.DataAnnotations;

public class Author
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    [MaxLength(2000)]
    public string? Bio { get; set; }

    // Navigation Property
    public ICollection<Book> Books { get; set; } = new List<Book>();
}