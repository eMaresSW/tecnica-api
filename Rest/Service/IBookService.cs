using Rest.Models;
using Rest.Models.Dto;

namespace Rest.Service
{
    public interface IBookService
    {

        public Task<ResponseModel<List<GetBooksDto>>> GetBooks();
        public Task<ResponseModel<GetBooksDto>> GetBookById(Guid id);
        public Task<ResponseModel<bool>> AddBook(AddBookDto book);

        public Task<ResponseModel<bool>> EditBook(EditBookDto book);

        public Task<ResponseModel<bool>> DeleteBook(Guid book);

    }
}
