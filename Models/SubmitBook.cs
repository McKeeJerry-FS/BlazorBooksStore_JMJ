using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BlazorBooksStore.Models.Enums;

namespace BlazorBooksStore.Models
{
    public class SubmitBook
    {
        [Required]
        [StringLength(80, MinimumLength = 3)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [StringLength(5000)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3)]
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        public string? ISBN { get; set; }

        [Required]
        [Range(0, 9999)]
        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [Range(typeof(decimal), "0", "10000.00")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        //TODO: Other properties to be added in the next sections

        public BookFormat Format { get; set; }
    }
}
