using BlazorBooksStore.Models;

namespace BlazorBooksStore.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginUserAsync(LoginRequest requestModel);
    }
}
