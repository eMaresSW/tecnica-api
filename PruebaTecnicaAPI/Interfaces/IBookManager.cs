using PruebaTecnicaAPI.Models;

namespace PruebaTecnicaAPI.Interfaces
{
    public interface IBookManager
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(Guid idBook);
        Task<bool> CreateBook(BookModel book);
        Task<bool> UpdateBook(BookModel book);
        Task<bool> DeleteBook(Guid id);
    }
}
