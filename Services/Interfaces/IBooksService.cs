using BlazorBooksStore.Models;
namespace BlazorBooksStore.Services.Interfaces
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooksAsync();
    }
}
