using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TecnicalApi.Models;
using TecnicalApi.Repository.Interfaces;

namespace TecnicalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookInterface _book_Interface;

        public BookController(ILogger<BookController> logger, IBookInterface bookInterface)
        {
            _logger = logger;
            _book_Interface = bookInterface;
        }

        [HttpGet("GetAll")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<IActionResult> GetAllBooks()
        {
            if (ModelState.IsValid)
            {
                List<BookModel> book_Models = await _book_Interface.GetAllBooks();
                return StatusCode(StatusCodes.Status200OK, book_Models);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
        }

        [HttpGet("GetById")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<IActionResult> GetById(Guid book_Id)
        {
            if (ModelState.IsValid)
            {
                BookModel book_Models = await _book_Interface.GetById(book_Id);
                return StatusCode(StatusCodes.Status200OK, book_Models);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
        }

        [HttpPost("Create")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<IActionResult> Create(BookModel book_Model)
        {
            BookModel book_Models = await _book_Interface.CreateBook(book_Model);
            return StatusCode(StatusCodes.Status200OK, book_Models);
        }

        [HttpPut("Update")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<IActionResult> Update(BookModel book_Model)
        {
            BookModel book_Models = await _book_Interface.UpdateBook(book_Model);
            return StatusCode(StatusCodes.Status200OK, book_Models);
        }

        [HttpPost("Delete")]
        [Consumes("application/json"), Produces("application/json")]
        public async Task<IActionResult> Delete(BookModel book_Model)
        {
            BookModel book_Models = await _book_Interface.DeleteBook(book_Model);
            return StatusCode(StatusCodes.Status200OK, book_Models);
        }
    }
}
