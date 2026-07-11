using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Category
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
