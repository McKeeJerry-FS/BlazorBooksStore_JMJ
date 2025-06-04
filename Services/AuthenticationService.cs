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
                throw new Exception("Oops!! Something must've gone wrong");
            }
        }
    }
}