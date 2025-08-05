using PruebaTecnicaAPI.Interfaces;
using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Repositories
{
    public class BookManager : IBookManager
    {
        public List<BookModel> books = new List<BookModel>
    {
        new BookModel
        {
            Id = Guid.NewGuid(),
            Title = "The Lost World",
            Author = "John Smith",
            ISBN = "978-1234567890",
            PublishDate = new DateTime(2001, 5, 21),
            Summary = "A thrilling adventure into the unknown."
        },
        new BookModel
        {
            Id = Guid.NewGuid(),
            Title = "Mystic Waters",
            Author = "Alice Brown",
            ISBN = "978-0987654321",
            PublishDate = new DateTime(2015, 11, 10),
            Summary = "An epic tale of courage and survival on the high seas."
        },
        new BookModel
        {
            Id = Guid.NewGuid(),
            Title = "Journey to the Stars",
            Author = "David Johnson",
            ISBN = "978-1122334455",
            PublishDate = new DateTime(2010, 3, 18),
            Summary = "A journey beyond the limits of imagination."
        },
        new BookModel
        {
            Id = Guid.NewGuid(),
            Title = "C# in Depth",
            Author = "Sarah Lee",
            ISBN = "978-2233445566",
            PublishDate = new DateTime(2019, 8, 7),
            Summary = "A comprehensive guide to mastering C# programming."
        },
        new BookModel
        {
            Id = Guid.NewGuid(),
            Title = "Hidden Realms",
            Author = "Michael Adams",
            ISBN = "978-6677889900",
            PublishDate = new DateTime(2005, 2, 14),
            Summary = "Discovering the secrets of an ancient civilization."
        }
    };
        public async Task<bool> CreateBook(BookModel book)
        {
            books.Add(book);
            return true;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var bookToDelete = books.FirstOrDefault(x => x.Id == id);
            if (bookToDelete == null)
            {
                return false;
            }
            books.Remove(bookToDelete);
            return true;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return books;
        }

        public async Task<BookModel> GetBookById(Guid idBook)
        {
            var book = books.Where(x=>x.Id == idBook).FirstOrDefault();
            return book != null ? book : new BookModel();
        }

        public async Task<bool> UpdateBook(BookModel book)
        {
            var bookToUpdate = books.FirstOrDefault(x => x.Id == book.Id);
            if (bookToUpdate == null)
            {
                return false;
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
            bookToUpdate.ISBN = book.ISBN;
            bookToUpdate.PublishDate = book.PublishDate;
            bookToUpdate.Summary = book.Summary;

            return true;
        }
    }
}
