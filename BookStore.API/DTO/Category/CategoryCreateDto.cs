using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
