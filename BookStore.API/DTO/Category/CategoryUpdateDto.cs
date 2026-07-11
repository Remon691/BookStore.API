using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Category
{
    public class CategoryUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
