namespace tecnica_api.Dto
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Summary { get; set; }

    }
}
