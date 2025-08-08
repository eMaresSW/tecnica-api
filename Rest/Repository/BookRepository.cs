using Rest.Entities;
using Rest.Models;
using Rest.Models.Dto;
using System.Net;

namespace Rest.Repository
{
    public class BookRepository : IBookRepository
    {
        public async Task<ResponseModel<GetBooksDto>> GetBookById(Guid id)
        {
            ResponseModel<GetBooksDto> response = new ResponseModel<GetBooksDto>();
            try
            {
                List<Book> books = new List<Book>();
                List<GetBooksDto> booksDto = new List<GetBooksDto>();
                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b4c3"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b443"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                var bookResult = books.FirstOrDefault(b => b.Id == id);


                var found = new GetBooksDto
                {
                    Title = bookResult.Title,
                    Author = bookResult.Author,
                    Isbn = bookResult.Isbn,
                    PublishedDate = bookResult.PublishedDate,
                    Summar = bookResult.Summar
                };

                response.Result = found;
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while fetching books.";
                return response;
            }
        }

        public async Task<ResponseModel<bool>> AddBook(AddBookDto book)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {


                var found = new Book
                {
                    Id = Guid.NewGuid(),
                    Title = book.Title,
                    Author = book.Author,
                    Isbn = book.Isbn,
                    PublishedDate = book.PublishedDate,
                    Summar = book.Summar
                };

                response.Result = true;
                response.Message = "Book added successfully.";
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while fetching books.";
                return response;
            }
        }

        public async Task<ResponseModel<List<GetBooksDto>>> GetBooks()
        {
            ResponseModel<List<GetBooksDto>> response = new ResponseModel<List<GetBooksDto>>();
            try
            {
                List<Book> books = new List<Book>();
                List<GetBooksDto> booksDto = new List<GetBooksDto>();
                books.Add(new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                books.ForEach(book =>
                {
                    booksDto.Add(new GetBooksDto
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Isbn = book.Isbn,
                        PublishedDate = book.PublishedDate,
                        Summar = book.Summar
                    });
                });
                response.Result = booksDto;
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while fetching books.";
                return response;
            }




        }

        public async Task<ResponseModel<bool>> EditBook(EditBookDto book)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                List<Book> books = new List<Book>();
                List<GetBooksDto> booksDto = new List<GetBooksDto>();
                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b4c3"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b443"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                var bookResult = books.FirstOrDefault(b => b.Id == book.Id);

                if (bookResult == null)
                {
                    response.Success = false;
                    response.Message = "Book not found.";
                    return response;
                }

                bookResult.Title = book.Title;
                bookResult.Author = book.Author;
                bookResult.Isbn = book.Isbn;
                bookResult.PublishedDate = book.PublishedDate;
                bookResult.Summar = book.Summar;

                response.Result = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while updatate a book.";
                return response;
            }
        }

        public async Task<ResponseModel<bool>> DeleteBook(Guid book)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                List<Book> books = new List<Book>();
                List<GetBooksDto> booksDto = new List<GetBooksDto>();
                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b4c3"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                books.Add(new Book
                {
                    Id = Guid.Parse("6afa5817-634b-4177-a99a-e99b2041b443"),
                    Title = "Book One",
                    Author = "Author One",
                    Isbn = "1234567890",
                    PublishedDate = DateTime.Now,
                    Summar = "This is the summary of Book One."
                });

                var bookResult = books.FirstOrDefault(b => b.Id == book);

                if (bookResult == null)
                {
                    response.Success = false;
                    response.Message = "Book not found.";
                    return response;
                }
                Book bookToDelete = new Book
                {
                    Id = bookResult.Id,
                    Title = bookResult.Title,
                    Author = bookResult.Author,
                    Isbn = bookResult.Isbn,
                    PublishedDate = bookResult.PublishedDate,
                    Summar = bookResult.Summar
                };

                books.Remove(bookToDelete);

                response.Result = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "An error occurred while delete a book.";
                return response;
            }
        }
    }
}
