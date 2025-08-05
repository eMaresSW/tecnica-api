namespace PruebaTecnicaAPI.Models
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string Summary { get; set; } = string.Empty;
    }
}
