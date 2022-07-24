using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    //used by both AddBook and UpdateBook
    public class UpdateBookViewModel
    {
        public IList<Genre> Genres { get; set; }
        public Book Book { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
