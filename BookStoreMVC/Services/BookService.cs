using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.BookViewModels;

namespace BookStoreMVC.Services
{
    public class BookService : IBookService
    {
        private readonly IAppData _data;

        public BookService(IAppData data)
        {
            _data = data;
        }

        public async Task<int> Add(UpdateBookViewModel book)
        {
            return await _data.BookRepository.Add(GetBookFromUpdateViewModel(book));
        }

        public async Task<int> Add(Book book)
        {
            return await _data.BookRepository.Add(book);
        }

        public async Task<int> AddAuthor(int id, int authorId)
        {
            return await _data.BookRepository.AddAuthor(id, authorId);
        }

        public async Task<int> AddGenre(int id, int genreId)
        {
            return await _data.BookRepository.AddGenre(id, genreId);
        }

        public async Task<int> DeleteAuthor(int id, int authorId)
        {
            return await _data.BookRepository.DeleteAuthor(id, authorId);
        }

        public async Task<int> DeleteGenre(int id, int genreId)
        {
            return await _data.BookRepository.DeleteGenre(id, genreId);
        }

        public async Task<int> Delete(int id)
        {
            return await _data.BookRepository.Delete(id);
        }

        public async Task<int> Edit(UpdateBookViewModel book)
        {
            return await _data.BookRepository.Edit(GetBookFromUpdateViewModel(book));
        }

        public async Task<int> Edit(Book book)
        {
            return await _data.BookRepository.Edit(book);
        }

        public async Task<AllBooksViewModel> GetAll()
        {
            int count = await _data.BookRepository.Count();
            var books = await _data.BookRepository.Get();
            return new()
            {
                Items = books,
                Count = count
            };
        }

        public async Task<SearchBySomeBookViewModel> GetByAuthor(int id)
        {
            var author = await _data.AuthorRepository.Get(id);
            if (author == null)
            {
                return null;
            }
            var books = await _data.BookRepository.GetByAuthor(id);
            var count = books.Count();
            return new()
            {
                SearchBy = "Author",
                SearchValue = author.Name,
                Items = books,
                Count = count
            };
        }

        public async Task<SearchBySomeBookViewModel> GetByGenre(int id)
        {
            var genre = await _data.GenreRepository.Get(id);
            if (genre == null)
            {
                return null;
            }
            var books = await _data.BookRepository.GetByGenre(id);
            var count = books.Count();
            return new()
            {
                SearchBy = "Genre",
                SearchValue = genre.Name,
                Items = books,
                Count = count
            };
        }

        public async Task<Book> GetById(int id)
        {
            return await _data.BookRepository.Get(id);
        }

        public async Task<UpdateBookViewModel> GetViewModelByBookId(int id)
        {
            var book = await this.GetById(id);
            if (book == null)
            {
                return null;
            }
            var authors = await _data.AuthorRepository.GetByBookId(id);
            var genres = await _data.GenreRepository.GetByBookId(id);
            return new()
            {
                Book = book,
                Authors = (IList<Author>)authors,
                Genres = (IList<Genre>)genres
            };
        }

        private Book GetBookFromUpdateViewModel(UpdateBookViewModel viewModel)
        {
            Book book = new Book
            {
                Title = viewModel.Book.Title,
                Price = viewModel.Book.Price,
                Pages = viewModel.Book.Pages,
                Description = viewModel.Book.Description
            };
            foreach (var author in viewModel.Authors)
            {
                book.AuthorsIds.Add(author.Id);
            }
            foreach (var genre in viewModel.Genres)
            {
                book.GenresIds.Add(genre.Id);
            }
            return book;
        }
    }
}
