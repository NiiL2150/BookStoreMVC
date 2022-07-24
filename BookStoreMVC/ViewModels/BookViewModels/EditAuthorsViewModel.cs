using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public class EditAuthorsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> BookAuthors { get; set; }
        public IEnumerable<Author> NonAuthors { get; set; }
        public EditAuthorsViewModel(Book book, IEnumerable<Author> allAuthors, IEnumerable<Author> bookAuthors)
        {
            Book = book;
            BookAuthors = bookAuthors;
            NonAuthors = allAuthors.ExceptBy(bookAuthors.Select(x=>x.Id), x => x.Id);
        }
    }
}
