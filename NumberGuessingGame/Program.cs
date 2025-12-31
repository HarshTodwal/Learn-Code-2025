using NumberGuessingGame.Game;
using NumberGuessingGame.Services;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main()
        {
            var numberGenerator = new NumberGenerator();
            var guessValidator = new GuessValidator(1, 100);
            var consoleIO = new ConsoleInputOutput();

            var game = new GuessingGame(numberGenerator, guessValidator, consoleIO);
            game.Start();
        }
    }
}
