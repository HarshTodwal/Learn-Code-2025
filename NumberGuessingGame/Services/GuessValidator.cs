namespace NumberGuessingGame.Services
{
    public class GuessValidator
    {
        private readonly int _min;
        private readonly int _max;

        public GuessValidator(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public bool IsValid(string input, out int guess)
        {
            return int.TryParse(input, out guess) &&
                   guess >= _min &&
                   guess <= _max;
        }
    }
}
