using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public class BookAuthorViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
