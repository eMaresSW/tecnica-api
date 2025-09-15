using Microsoft.AspNetCore.Mvc;
using tecnica_api.Dto;
using tecnica_api.Model;

namespace tecnica_api.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();
        private static Guid bookId = Guid.NewGuid();


        [HttpGet]
        public IActionResult GetAll() => Ok(books);

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(book);

        }


        [HttpPost]

        public IActionResult create(Book book) {

            var bookNew {
                Id = bookId,
            Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    PublishedDate = book.PublishedDate,
                    Summary = book.Summary


            }
            books.Add(bookNew);
            return CreatedAtAction(nameof(GetById), new { id = book.Id, title = book.Title, author = book.Author,
                ISBN = book.ISBN, publishedDate = book.PublishedDate, summary = book.Summary });

        }

        [HttpPut("{id}")]
        public IActionResult update(Book book) {
            var bookU = books.FirstOrDefault(b => b.Id == book.id);
            if (book == null) return NotFound();
            bookU.Title = book.Title;
            bookU.Author = book.Author;
            bookU.PublishedDate = book.PublishedDate;
            bookU.Summary = book.Summary;
            return Ok(bookU);


        }
        [HttpDelete("{id}")]
        public IActionResult delete(Guid idbook) {



            var bookU = books.FirstOrDefault(a => a.Id == idbook);
}
