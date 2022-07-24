using BookStoreMVC.Models;
using BookStoreMVC.Services;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            return View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Author(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Authors");
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author model)
        {
            int authorId = await _service.Add(model);
            return RedirectToAction("Author", new { id = authorId });
        }

        [HttpGet]
        public async Task<IActionResult> EditAuthor(int id)
        {
            Author author = await _service.GetById(id);
            if (author == null)
            {
                return RedirectToAction("Authors");
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(Author author)
        {
            int authorId = await _service.Edit(author);
            return RedirectToAction("Author", new { id = authorId });
        }
    }
}
