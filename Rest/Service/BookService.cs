using Rest.Models;
using Rest.Models.Dto;
using Rest.Repository;

namespace Rest.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ResponseModel<GetBooksDto>> GetBookById(Guid id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<ResponseModel<bool>> AddBook(AddBookDto book)
        {
            return await _bookRepository.AddBook(book);
        }

        public async Task<ResponseModel<List<GetBooksDto>>> GetBooks()
        {
          return await _bookRepository.GetBooks();
        }

        public async Task<ResponseModel<bool>> EditBook(EditBookDto book)
        {
            return await _bookRepository.EditBook(book);
        }

        public Task<ResponseModel<bool>> DeleteBook(Guid book)
        {
            throw new NotImplementedException();
        }
    }
}
