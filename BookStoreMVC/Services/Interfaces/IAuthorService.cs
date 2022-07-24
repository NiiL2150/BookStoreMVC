using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.AuthorViewModels;

namespace BookStoreMVC.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AllAuthorsViewModel> GetAll();
        Task<Author> GetById(int id);
        Task<int> Add(Author author);
        Task<int> Edit(Author author);
        Task<int> Delete(int id);
        Task<IEnumerable<Author>> GetByBookId(int id);
    }
}
