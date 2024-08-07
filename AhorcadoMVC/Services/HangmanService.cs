namespace AhorcadoMVC.Services
{
    public class HangmanService
    {
        public string WordToGuess { get; private set; }
        public List<char> GuessedLetters { get; private set; } = new List<char>();
        public int WrongGuesses { get; private set; } = 0;
        public List<string> HangmanImages { get; private set; }
        private List<string> WordList { get; set; }


        public HangmanService()
        {
            HangmanImages = new List<string>
            {
                "Images/hangman0.png",
                "Images/hangman1.png",
                "Images/hangman2.png",
                "Images/hangman3.png",
                "Images/hangman4.png",
                "Images/hangman5.png",
                "Images/hangman6.png"
            };
            WordList = new List<string>
            {
                "example",
                "hangman",
                "programming",
                "dotnet",
                "framework",
                "mvc",
                "controller",
                "service",
                "model",
                "view"
            };
        }

        public void StartNewGame()
        {
            WordToGuess = GetRandomWord();
            GuessedLetters.Clear();
            WrongGuesses = 0;
        }
        private string GetRandomWord()
        {
            var random = new Random();
            int index = random.Next(WordList.Count);
            return WordList[index];
        }

        public void MakeGuess(char letter)
        {
            if (WordToGuess.Contains(letter))
            {
                if (!GuessedLetters.Contains(letter))
                {
                    GuessedLetters.Add(letter);
                }
            }
            else
            {
                WrongGuesses++;
            }
        }

        public string GetDisplayWord()
        {
            var displayWord = string.Empty;
            foreach (var letter in WordToGuess)
            {
                if (GuessedLetters.Contains(letter))
                {
                    displayWord += letter + " ";
                }
                else
                {
                    displayWord += "_ ";
                }
            }
            return displayWord.Trim();
        }

        public bool IsWordGuessed()
        {
            foreach (var letter in WordToGuess)
            {
                if (!GuessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsGameOver()
        {
            return WrongGuesses >= HangmanImages.Count - 1;
        }
    }
}
