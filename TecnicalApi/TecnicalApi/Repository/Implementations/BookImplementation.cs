using TecnicalApi.Models;
using TecnicalApi.Repository.Interfaces;

namespace TecnicalApi.Repository.Implementations
{
    public class BookImplementation : IBookInterface
    {
        private List<BookModel> book_Models = new List<BookModel>();

        public async Task<BookModel> CreateBook(BookModel book_Model)
        {
            book_Models.Add(book_Model);
            return book_Model;
        }

        public async Task<BookModel> DeleteBook(BookModel book_Model)
        {
            book_Models.Remove(book_Model);
            return book_Model;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return book_Models;
        }

        public async Task<BookModel> GetById(Guid book_Id)
        {
            return book_Models.Where(wh => wh.Id == book_Id).ToList()[0];
        }

        public async Task<BookModel> UpdateBook(BookModel book_Model)
        {
            int index = book_Models.IndexOf(book_Model);
            book_Models[index] = book_Model;
            return book_Model;
        }
    }
}
