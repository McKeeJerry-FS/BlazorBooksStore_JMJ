using System;

namespace BlazorBooksStore.Api.Models;

public class LoginRequest
{
  public string? Username { get; set; }
  public string? Password { get; set; }
}
