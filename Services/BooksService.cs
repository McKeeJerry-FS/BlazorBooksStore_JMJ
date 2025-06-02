using System;
using System.Net.Http.Json;
using BlazorBooksStore.Models;
using BlazorBooksStore.Services.Interfaces;

namespace BlazorBooksStore.Services;

public class BooksService : IBooksService
{
  private readonly HttpClient _httpClient;

  public BooksService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<List<Book>>? GetAllBooksAsync()
  {
    var response = await _httpClient.GetAsync("/books");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Successfully fetched books from API.");
            return await response.Content.ReadFromJsonAsync<List<Book>?>();
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            throw new Exception($"Error fetching books: {errorResponse?.Message ?? "Unknown error"}");
            // TODO: Handle error appropriately
        }
  }

  public Task<Book?> GetBookByIdAsync(string? id)
  {
    throw new NotImplementedException();
  }
}
