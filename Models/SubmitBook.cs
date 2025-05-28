namespace BlazorBooksStore.Models
{
    public class SubmitBook
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int PagesCount { get; set; }
        public decimal Price { get; set; }
        //TODO: Other properties to be added in the next sections
    }
}
