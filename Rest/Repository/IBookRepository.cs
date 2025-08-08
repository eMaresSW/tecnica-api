using Rest.Models.Dto;
using Rest.Models;

namespace Rest.Repository
{
    public interface IBookRepository
    {
        public Task<ResponseModel<List<GetBooksDto>>> GetBooks();

        public Task<ResponseModel<GetBooksDto>> GetBookById(Guid id);

        public Task<ResponseModel<bool>> AddBook(AddBookDto book);
        public Task<ResponseModel<bool>> EditBook(EditBookDto book);

        public Task<ResponseModel<bool>> DeleteBook(Guid book);


    }
}
