namespace AhorcadoMVC.Models
{
    public class HangmanModel
    {
        public string WordToGuess { get; set; }
        public List<char> GuessedLetters { get; set; }
        public int WrongGuesses { get; set; }
        public string DisplayWord { get; set; }
        public string HangmanImage { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsWordGuessed { get; set; }
    }
}
