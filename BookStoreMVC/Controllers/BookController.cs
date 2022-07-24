using BookStoreMVC.Models;
using BookStoreMVC.Services;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;

        public BookController(IBookService service, IAuthorService authorService, IGenreService genreService)
        {
            _service = service;
            _authorService = authorService;
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            var books = await _service.GetAll();
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> BookAuthor(int id)
        {
            var book = await _service.GetByAuthor(id);
            return book == null ? RedirectToAction("Books") : View("Books", book);
        }

        [HttpGet]
        public async Task<IActionResult> BookGenre(int id)
        {
            var book = await _service.GetByGenre(id);
            return book == null ? RedirectToAction("Books") : View("Books", book);
        }

        [HttpGet]
        public async Task<IActionResult> Book(int id)
        {
            return View(await _service.GetViewModelByBookId(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Books");
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book model)
        {
            int bookId = await _service.Add(model);
            return RedirectToAction("Book", new { id = bookId });
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(int id)
        {
            var book = await _service.GetViewModelByBookId(id);
            if (book == null)
            {
                return RedirectToAction("Books");
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(UpdateBookViewModel model)
        {
            Book book = model.Book;
            int bookId = await _service.Edit(book);
            return RedirectToAction("Book", new { id = bookId });
        }

        [HttpGet]
        public async Task<IActionResult> EditAuthors(int id)
        {
            var book = await _service.GetById(id);
            var allAuthors = await _authorService.GetAll();
            var bookAuthors = await _authorService.GetByBookId(id);
            var model = new EditAuthorsViewModel(book, allAuthors.Items, bookAuthors);
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> AddAuthor(int id, int authorId)
        {
            await _service.AddAuthor(id, authorId);
            return RedirectToAction("EditAuthors", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAuthor(int id, int authorId)
        {
            await _service.DeleteAuthor(id, authorId);
            return RedirectToAction("EditAuthors", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> EditGenres(int id)
        {
            var book = await _service.GetById(id);
            var allGenres = await _genreService.GetAll();
            var bookGenres = await _genreService.GetByBookId(id);
            var model = new EditGenresViewModel(book, allGenres.Items, bookGenres);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddGenre(int id, int genreId)
        {
            await _service.AddGenre(id, genreId);
            return RedirectToAction("EditGenres", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGenre(int id, int genreId)
        {
            await _service.DeleteGenre(id, genreId);
            return RedirectToAction("EditGenres", new { id = id });
        }
    }
}