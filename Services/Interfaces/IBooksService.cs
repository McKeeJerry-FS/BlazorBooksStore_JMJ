using BlazorBooksStore.Models;
namespace BlazorBooksStore.Services.Interfaces
{
    public interface IBooksService
    {
        Task<List<Book>>? GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(string? id);
        Task AddBookAsync(SubmitBook book);
    }
}
