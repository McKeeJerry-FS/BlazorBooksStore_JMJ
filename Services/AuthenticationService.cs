using BlazorBooksStore.Models;
using BlazorBooksStore.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorBooksStore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest requestModel)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginRequest>("authentication/login", requestModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            else
            {
                var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                Console.WriteLine(error);
                throw new Exception(error?.Message);
                // TODO: Handle error more gracefully, e.g., show a notification to the user
            }
        }
    }
}