using BookStoreMVC.Models;

namespace BookStoreMVC.ViewModels.BookViewModels
{
    public interface ISearchBySomeBookViewModel
    {
        public string SearchBy { get; set; }
        public string SearchValue { get; set; }
        public IEnumerable<Book> Items { get; set; }
        public int Count { get; set; }
    }
}
