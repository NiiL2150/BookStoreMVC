namespace BookStoreMVC.ViewModels.IViewModels
{
    public interface IAllViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Count { get; set; }
    }
}
