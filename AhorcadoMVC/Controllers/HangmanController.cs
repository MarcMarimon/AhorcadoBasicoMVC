using AhorcadoMVC.Models;
using AhorcadoMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AhorcadoMVC.Controllers
{
    public class HangmanController : Controller
    {
        private static HangmanService _hangmanService = new HangmanService();

        [HttpGet]
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_hangmanService.WordToGuess))
            {
                StartNewGame();
            }

            var model = new HangmanModel();

            model.WordToGuess = _hangmanService.WordToGuess;
            model.GuessedLetters = _hangmanService.GuessedLetters;
            model.WrongGuesses = _hangmanService.WrongGuesses;
            model.DisplayWord = _hangmanService.GetDisplayWord();
            model.HangmanImage = _hangmanService.HangmanImages[_hangmanService.WrongGuesses];
            model.IsGameOver = _hangmanService.IsGameOver();
            model.IsWordGuessed = _hangmanService.IsWordGuessed();
            

            if (TempData["GameOver"]!=null)
                model.IsGameOver = true;

            return View(model);
        }

        [HttpPost]
        public IActionResult Guess(char letter)
        {
            _hangmanService.MakeGuess(letter);

            if (_hangmanService.IsWordGuessed() || _hangmanService.IsGameOver())
            {
                TempData["GameOver"] = true;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult StartNewGame()
        {
            _hangmanService.StartNewGame();
            return RedirectToAction("Index");
        }
    }
}