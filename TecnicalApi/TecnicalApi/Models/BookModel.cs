using System.ComponentModel.DataAnnotations;

namespace TecnicalApi.Models
{
    public class BookModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public string Summary { get; set; }

    }
}
