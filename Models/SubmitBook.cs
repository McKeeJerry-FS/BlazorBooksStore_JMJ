using System.ComponentModel.DataAnnotations;
using BlazorBooksStore.Models.Enums;

namespace BlazorBooksStore.Models
{
    public class SubmitBook
    {
        [Required]
        [StringLength(80, MinimumLength =3)]
        public string? Title { get; set; }
        [StringLength(5000)]
        public string? Description { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 3)]
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        [Required]    
        [Range(0, 9999)]
        public int PagesCount { get; set; }
        [Range(typeof(decimal), "0", "10000.00")]
        public decimal Price { get; set; }
        //TODO: Other properties to be added in the next sections

        public BookFormat Format { get; set; }
    }
}
