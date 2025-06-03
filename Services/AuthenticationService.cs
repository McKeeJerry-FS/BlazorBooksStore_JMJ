using BlazorBooksStore.Exceptions;
using BlazorBooksStore.Models;
using BlazorBooksStore.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorBooksStore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(HttpClient httpClient, ILogger<AuthenticationService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest requestModel)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginRequest>("authentication/login", requestModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponse>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new ApiResponseException(error);
            }
            else
            {
                var content = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                _logger.LogError($"Failed to log the user in. Status Code: {response.StatusCode}", content);
                throw new Exception("Oops!! Something must've gone wrong");
            }
        }
    }
}