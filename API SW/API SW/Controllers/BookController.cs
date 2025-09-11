using API_SW.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_SW.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly List<Book> libros = new()
        {
            new Book
            {
                Id = Guid.Parse("b1a8e2c2-4e3a-4c7a-9e2a-1f2b3c4d5e6f"),
                Title = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "9780132350884",
                PublishedDate = DateTime.Parse("2008-08-01T00:00:00"),
                Summary = "A handbook of agile software craftsmanship."
            },
            new Book
            {
                Id = Guid.Parse("c2b9f3d4-5e6b-4a8c-9d2b-2f3c4d5e6f7a"),
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                ISBN = "9780201616224",
                PublishedDate = DateTime.Parse("1999-10-30T00:00:00"),
                Summary = "Journey to mastery in software development."
            },
            new Book
            {
                Id = Guid.Parse("d3c0a4e5-6f7c-4b9d-8e3c-3f4d5e6f7a8b"),
                Title = "Design Patterns",
                Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                ISBN = "9780201633610",
                PublishedDate = DateTime.Parse("1994-10-31T00:00:00"),
                Summary = "Elements of reusable object-oriented software."
            },
            new Book
            {
                Id = Guid.Parse("e4d1b5f6-7a8d-4c0e-7f4d-4e5f6a7b8c9d"),
                Title = "Refactoring",
                Author = "Martin Fowler",
                ISBN = "9780201485677",
                PublishedDate = DateTime.Parse("1999-07-08T00:00:00"),
                Summary = "Improving the design of existing code."
            },
            new Book
            {
                Id = Guid.Parse("f5e2c6a7-8b9e-4d1f-6a5e-5f6a7b8c9d0e"),
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein",
                ISBN = "9780262033848",
                PublishedDate = DateTime.Parse("2009-07-31T00:00:00"),
                Summary = "Comprehensive textbook on algorithms."
            }
        };

        [HttpGet]
        [Route("ListarLibros")]
        public async Task<IActionResult> ListarLibros()
        {
            var listadoLibros = libros;
            return Ok(listadoLibros);
        }

        [HttpGet]
        [Route("ObtenerLibroPorId/{idLibro}")]
        public async Task<IActionResult> ObtenerLibroPorId(Guid idLibro)
        {
            var libro = libros.FirstOrDefault(r => r.Id == idLibro);
            if (libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }

        [HttpPost]
        [Route("CrearLibro")]
        public async Task<IActionResult> CrearLibro([FromBody] Book libro)
        {
            if (libro == null ||
            string.IsNullOrWhiteSpace(libro.Title) ||
            string.IsNullOrWhiteSpace(libro.Author))
            {
                return BadRequest("Title and Author are required and cannot be null or empty.");
            }

            if (libros.Any(b => b.Id == libro.Id))
            {
                return Conflict("A book with the same Id already exists.");
            }

            libros.Add(libro);
            return Ok(libros);
        }
        [HttpPut]
        [Route("ActualizarLibro")]
        public async Task<IActionResult> ActualizarLibro([FromBody] Book libro)
        {
            var index = libros.FindIndex(b => b.Id == libro.Id);
            if (index == -1)
                return NotFound();
            if (libro == null ||
            string.IsNullOrWhiteSpace(libro.Title) ||
            string.IsNullOrWhiteSpace(libro.Author))
            {
                return BadRequest("Title and Author are required and cannot be null or empty.");
            }
            libros[index] = libro;
            return Ok(libros);
        }
        [HttpDelete]
        [Route("EliminarLibro/{idLibro}")]
        public async Task<IActionResult> EliminarLibro(Guid idLibro)
        {
            var libro = libros.Find(b => b.Id == idLibro);
            if (libro == null)
                return NotFound();
            libros.Remove(libro);
            return Ok(libros);
        }
    }
}
