using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.Models;
using Rest.Models.Dto;
using Rest.Service;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetBooks")]
        public async Task<ActionResult<ResponseModel<List<GetBooksDto>>>> GetBooks()
        {
           return await _bookService.GetBooks();
        }

        [HttpGet("GetBooksById")]
        public async Task<ActionResult<ResponseModel<GetBooksDto>>> GetBooksById(Guid id)
        {
            return await _bookService.GetBookById(id);
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult<ResponseModel<bool>>> AddBook(AddBookDto book)
        {
            return await _bookService.AddBook(book);
        }

        [HttpPut("EditBook")]
        public async Task<ActionResult<ResponseModel<bool>>> EditBook(EditBookDto book)
        {
            return await _bookService.EditBook(book);
        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteBook(Guid book)
        {
            return await _bookService.DeleteBook(book);
        }


    }
}
