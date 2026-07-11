using System.ComponentModel.DataAnnotations;

public class Publisher
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;

    // Navigation Property
    public ICollection<Book> Books { get; set; } = new List<Book>();
}