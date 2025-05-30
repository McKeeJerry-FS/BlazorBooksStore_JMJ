using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorBooksStore.Api.Models;

namespace BlazorBooksStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<LoginResponse>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("login")]
        public Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new LoginResponse()));
        }

        [ProducesResponseType(200, Type = typeof(ApiSuccessResponse<bool>))]
        [ProducesResponseType(400, Type = typeof(ApiErrorResponse))]
        [HttpPost("register")]
        public Task<IActionResult> Register([FromBody] RegisterUserRequest model)
        {
            // Validate the model 
            return Task.FromResult<IActionResult>(Ok(new ApiSuccessResponse<bool>()));
        }
    }
}
