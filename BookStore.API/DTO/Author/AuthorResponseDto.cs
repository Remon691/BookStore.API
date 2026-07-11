using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Author
{
    public class AuthorResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [MaxLength(2000)]
        public string? Bio { get; set; }
    }
}
