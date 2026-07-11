using BookStore.API.Models;

namespace BookStore.API.Areas.Identity.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);
    }
}
