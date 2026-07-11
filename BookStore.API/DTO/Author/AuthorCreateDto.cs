using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Author
{
    public class AuthorCreateDto
    {
        public string Name { get; set; } = null!;

        [MaxLength(2000)]
        public string? Bio { get; set; }
    }
}
