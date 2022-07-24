using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public class EditGenresViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Genre> BookGenres { get; set; }
        public IEnumerable<Genre> NonGenres { get; set; }
        public EditGenresViewModel(Book book, IEnumerable<Genre> allGenres, IEnumerable<Genre> bookGenres)
        {
            Book = book;
            BookGenres = bookGenres;
            NonGenres = allGenres.Except(bookGenres);
        }
    }
}
