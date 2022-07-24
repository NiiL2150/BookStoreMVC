using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.GenreViewModels;

namespace BookStoreMVC.Services.Interfaces
{
    public interface IGenreService
    {
        Task<AllGenresViewModel> GetAll();
        Task<Genre> GetById(int id);
        Task<int> Add(Genre genre);
        Task<int> Edit(Genre genre);
        Task<int> Delete(int id);
        Task<IEnumerable<Genre>> GetByBookId(int id);
    }
}
