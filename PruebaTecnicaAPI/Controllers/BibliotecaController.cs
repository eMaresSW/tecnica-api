using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Interfaces;
using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController(IBookManager bookMananger) : ControllerBase
    {
        private readonly IBookManager _bookManager = bookMananger;

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookManager.GetAllBooks());
        }

        [HttpGet]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookManager.GetBookById(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel book)
        {
            var updated = await _bookManager.UpdateBook(book);
            if (!updated)
                return Conflict("No se pudo actualizar el libro.");
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            return Ok(await _bookManager.DeleteBook(id));
        }
    }
}
