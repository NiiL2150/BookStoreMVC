using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.IViewModels;

namespace BookStoreMVC.ViewModels.AuthorViewModels
{
    public class AllAuthorsViewModel : IAllViewModel<Author>
    {
        public IEnumerable<Author> Items { get; set; }
        public int Count { get; set; }
    }
}
