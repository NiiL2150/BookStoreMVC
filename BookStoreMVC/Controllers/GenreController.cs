using BookStoreMVC.Models;
using BookStoreMVC.Services;
using BookStoreMVC.Services.Interfaces;
using BookStoreMVC.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreMVC.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Genres()
        {
            return View(await _service.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Genre(int id)
        {
            return View(await _service.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Genres");
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(Genre model)
        {
            int genreId = await _service.Add(model);
            return RedirectToAction("Genre", new { id = genreId });
        }

        [HttpGet]
        public async Task<IActionResult> EditGenre(int id)
        {
            Genre genre = await _service.GetById(id);
            if (genre == null)
            {
                return RedirectToAction("Genres");
            }
            return View(genre);
        }

        [HttpPost]
        public async Task<IActionResult> EditGenre(Genre genre)
        {
            int genreId = await _service.Edit(genre);
            return RedirectToAction("Genre", new {id = genreId});
        }
    }
}
