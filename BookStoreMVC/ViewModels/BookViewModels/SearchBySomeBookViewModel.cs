using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.IViewModels;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public class SearchBySomeBookViewModel : ISearchBySomeBookViewModel, IAllViewModel<Book>
    {
        public string SearchBy { get; set; }
        public string SearchValue { get; set; }
        public IEnumerable<Book> Items { get; set; }
        public int Count { get; set; }
    }
}
