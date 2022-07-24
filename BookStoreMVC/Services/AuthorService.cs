using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.AuthorViewModels;

namespace BookStoreMVC.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAppData _data;

        public AuthorService(IAppData data)
        {
            _data = data;
        }

        public async Task<int> Add(Author author)
        {
            return await _data.AuthorRepository.Add(author);
        }

        public async Task<int> Delete(int id)
        {
            return await _data.AuthorRepository.Delete(id);
        }

        public async Task<int> Edit(Author author)
        {
            return await _data.AuthorRepository.Edit(author);
        }

        public async Task<AllAuthorsViewModel> GetAll()
        {
            int count = await _data.AuthorRepository.Count();
            IEnumerable<Author> authors = await _data.AuthorRepository.Get();
            return new AllAuthorsViewModel() { Count = count, Items = authors };
        }

        public async Task<Author> GetById(int id)
        {
            return await _data.AuthorRepository.Get(id);
        }

        public async Task<IEnumerable<Author>> GetByBookId(int id)
        {
            return await _data.AuthorRepository.GetByBookId(id);
        }
    }
}
