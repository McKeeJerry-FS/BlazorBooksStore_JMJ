using BlazorBooksStore.Exceptions;
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
            var response = await _httpClient.PostAsJsonAsync("authentication/login", requestModel);
            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (loginResponse == null)
                {
                    throw new Exception("Failed to deserialize login response.");
                }
                return loginResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                if (error == null)
                {
                    throw new Exception("Failed to deserialize error response.");
                }
                throw new ApiResponseException(error);
            }
            else
            {
                var content = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                throw new Exception("Oops!! Something must've gone wrong");
            }
        }
    }
}