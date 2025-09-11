namespace API_SW.Entidades
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Summary { get; set; }
    }
}
