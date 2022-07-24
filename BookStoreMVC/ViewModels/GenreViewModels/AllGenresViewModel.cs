using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.IViewModels;

namespace BookStoreMVC.ViewModels.GenreViewModels
{
    public class AllGenresViewModel : IAllViewModel<Genre>
    {
        public IEnumerable<Genre> Items { get; set; }
        public int Count { get; set; }
    }
}
