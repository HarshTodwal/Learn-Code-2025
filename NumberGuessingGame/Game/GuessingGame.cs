using NumberGuessingGame.Services;

namespace NumberGuessingGame.Game
{
    public class GuessingGame
    {
        private readonly NumberGenerator numberGenerator;
        private readonly GuessValidator guessValidator;
        private readonly ConsoleInputOutput consoleIO;

        public GuessingGame(
            NumberGenerator numberGenerator,
            GuessValidator guessValidator,
            ConsoleInputOutput consoleIO)
        {
            numberGenerator = numberGenerator;
            guessValidator = guessValidator;
            consoleIO = consoleIO;
        }

        public void Start(){
            int targetNumber = numberGenerator.Generate(1, 100);
            int attempts = 0;
            bool isGuessed = false;

            while (!isGuessed){
                string input = consoleIO.ReadInput("Guess a number between 1 and 100: ");

                if (!guessValidator.IsValid(input, out int guess)){
                    consoleIO.ShowMessage("Invalid input. Please enter a number between 1 and 100.");
                    continue;
                }
                attempts++;
                if (guess < targetNumber){
                    consoleIO.ShowMessage("Too low. Guess again.");
                }else if (guess > targetNumber){
                    consoleIO.ShowMessage("Too high. Guess again.");
                }else{
                    consoleIO.ShowMessage($"You guessed it in {attempts} guesses!");
                    isGuessed = true;
                }
            }
        }
    }
}
