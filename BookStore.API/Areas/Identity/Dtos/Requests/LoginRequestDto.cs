using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Areas.Identity.Dtos.Requests
{
    public class LoginRequestDto
    {


        [Required]
        public string EmailOrUserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [StringLength(100, MinimumLength = 8)]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
