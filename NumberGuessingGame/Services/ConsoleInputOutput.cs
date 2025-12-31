namespace NumberGuessingGame.Services
{
    public class ConsoleInputOutput
    {
        public string ReadInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
