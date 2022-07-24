using BookStoreMVC.Models;
using BookStoreMVC.ViewModels.BookViewModels;

namespace BookStoreMVC.Services.Interfaces
{
    public interface IBookService
    {
        Task<AllBooksViewModel> GetAll();
        Task<SearchBySomeBookViewModel> GetByGenre(int id);
        Task<SearchBySomeBookViewModel> GetByAuthor(int id);
        Task<Book> GetById(int id);
        Task<UpdateBookViewModel> GetViewModelByBookId(int id);
        Task<int> Add(UpdateBookViewModel book);
        Task<int> Add(Book book);
        Task<int> AddAuthor(int id, int authorId);
        Task<int> AddGenre(int id, int genreId);
        Task<int> DeleteAuthor(int id, int authorId);
        Task<int> DeleteGenre(int id, int genreId);
        Task<int> Edit(UpdateBookViewModel book);
        Task<int> Edit(Book book);
        Task<int> Delete(int id);
    }
}
