using BookStoreMVC.Repositories.Interfaces;

namespace BookStoreMVC.Repositories.Classes
{
    public class AppData : IAppData
    {
        private readonly BookRepository _bookRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly GenreRepository _genreRepository;

        public BookRepository BookRepository => _bookRepository ?? new();
        public AuthorRepository AuthorRepository => _authorRepository ?? new();
        public GenreRepository GenreRepository => _genreRepository ?? new();
    }
}
