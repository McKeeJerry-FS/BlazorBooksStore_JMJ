using System.Text.Json.Serialization;
using System;

namespace BlazorBooksStore.Models;

public class ApiErrorResponse
{
  [JsonPropertyName("message")]
  public string? Message { get; set; }
  [JsonPropertyName("errors")]
  public string[]? Errors { get; set; }
}
