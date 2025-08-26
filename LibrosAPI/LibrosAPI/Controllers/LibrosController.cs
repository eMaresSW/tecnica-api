using LibrosAPI.Context;
using LibrosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private static ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetAll()
        {
            var libros = await _context.Libros.ToListAsync();

            return libros;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetById(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro is null)
                return NotFound($"No se encontró el libro con el id {id}");

            return libro;
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> Create(Libro libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existeLibro = await _context.Libros.AnyAsync(x => x.Title == libro.Title && x.ISBN == libro.ISBN);
            if (existeLibro)
                return StatusCode(409, $"El libro con el título {libro.Title} y el ISBN {libro.ISBN} ya existe.");

            _context.Libros.Add(libro);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }

            return CreatedAtAction("GetById", new { Id = libro.Id}, libro);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> Update(int id, Libro libro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existeLibro = await _context.Libros.AnyAsync(x => x.Title == libro.Title && x.ISBN == libro.ISBN && x.Id == libro.Id);
            if (existeLibro)
                return StatusCode(409, $"El libro con el título {libro.Title} y el ISBN {libro.ISBN} ya existe.");

            _context.Libros.Update(libro);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Libro>> Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro is null)
                return NotFound($"No se encontró el libro con el id {id}");

            _context.Libros.Remove(libro);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NoContent();
        }
    }
}
