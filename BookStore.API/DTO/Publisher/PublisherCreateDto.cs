using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTO.Publisher
{
    public class PublisherCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
