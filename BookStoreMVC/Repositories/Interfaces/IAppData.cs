using BookStoreMVC.Repositories.Classes;

namespace BookStoreMVC.Repositories.Interfaces
{
    public interface IAppData
    {
        public BookRepository BookRepository { get; }
        public AuthorRepository AuthorRepository { get; }
        public GenreRepository GenreRepository { get; }
    }
}
