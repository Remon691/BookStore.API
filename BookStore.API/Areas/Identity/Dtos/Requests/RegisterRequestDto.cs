using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Areas.Identity.Dtos.Requests
{
    public class RegisterRequestDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [StringLength(100, MinimumLength = 8)]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string? Address { get; set; }
    }
}
