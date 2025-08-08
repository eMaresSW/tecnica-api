namespace Rest.Models.Dto
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Summar { get; set; }
    }
}
