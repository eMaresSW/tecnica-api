namespace LibrosAPI.Models
{
    public class Libro
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? ISBN { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Summary { get; set; }
    }
}
