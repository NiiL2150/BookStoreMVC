using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.GenreViewModels;

namespace BookStoreMVC.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAppData _data;

        public GenreService(IAppData data)
        {
            _data = data;
        }

        public async Task<int> Add(Genre author)
        {
            return await _data.GenreRepository.Add(author);
        }

        public async Task<int> Delete(int id)
        {
            return await _data.GenreRepository.Delete(id);
        }

        public async Task<int> Edit(Genre genre)
        {
            return await _data.GenreRepository.Edit(genre);
        }

        public async Task<AllGenresViewModel> GetAll()
        {
            int count = await _data.GenreRepository.Count();
            IEnumerable<Genre> genres = await _data.GenreRepository.Get();
            return new AllGenresViewModel() { Count = count, Items = genres };
        }

        public async Task<Genre> GetById(int id)
        {
            return await _data.GenreRepository.Get(id);
        }

        public async Task<IEnumerable<Genre>> GetByBookId(int id)
        {
            return await _data.GenreRepository.GetByBookId(id);
        }
    }
}
