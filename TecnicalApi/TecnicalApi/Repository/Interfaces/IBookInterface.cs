using TecnicalApi.Models;

namespace TecnicalApi.Repository.Interfaces
{
    public interface IBookInterface
    {
        public Task<List<BookModel>> GetAllBooks();

        public Task<BookModel> GetById(Guid book_Id);

        public Task<BookModel> CreateBook(BookModel book_Model);

        public Task<BookModel> UpdateBook(BookModel book_Model);

        public Task<BookModel> DeleteBook(BookModel bookModel);
    }
}
