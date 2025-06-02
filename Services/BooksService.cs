using System;
using System.Net.Http.Json;
using BlazorBooksStore.Models;
using BlazorBooksStore.Services.Interfaces;

namespace BlazorBooksStore.Services;

public class BooksService : IBooksService
{
  private readonly HttpClient _httpClient;
  private List<Book> _allBooks = new List<Book>(); // In-memory list to store books

  public BooksService(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task AddBookAsync(SubmitBook book)
  {
    var response = await _httpClient.PostAsJsonAsync("/books", book);
    if (!response.IsSuccessStatusCode)
    {
      var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
      Console.WriteLine(errorResponse?.Message ?? "Unknown error while adding book.");
    }
  }

  public async Task<List<Book>>? GetAllBooksAsync()
  {
    var response = await _httpClient.GetAsync("/books");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Successfully fetched books from API.");
            _allBooks = await response.Content.ReadFromJsonAsync<List<Book>?>() ?? new List<Book>();
            return _allBooks;
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
        var book = _allBooks.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(book);
  }
}
