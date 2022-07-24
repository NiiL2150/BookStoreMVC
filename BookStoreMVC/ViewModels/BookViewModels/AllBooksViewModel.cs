using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.IViewModels;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public class AllBooksViewModel : SearchBySomeBookViewModel, ISearchBySomeBookViewModel, IAllViewModel<Book>
    {
        public IEnumerable<Book> Items { get; set; }
        public int Count { get; set; }

        public AllBooksViewModel()
        {
            SearchBy = "";
            SearchValue = "";
        }
    }
}
