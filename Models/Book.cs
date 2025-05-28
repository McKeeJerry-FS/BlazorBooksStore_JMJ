using System.ComponentModel.DataAnnotations;
using BlazorBooksStore.Models.Enums;

namespace BlazorBooksStore.Models
{
    public class Book
    {
        
        public string? Title { get; set; }

        
        public string? AuthorName { get; set; } = string.Empty;
        public DateTime PublishingDate { get; set; }

        
        public decimal Price { get; set; }

        
        public string? Description { get; set; }
        public string? Id { get; set; }

        
        public int PagesCount { get; set; }

        public BookFormat Format { get; set; }
    }
}
