namespace SubarrayMeanCalculator.Services
{
    public class InputParser
    {
        public (int arraySize, int queryCount) ReadArrayAndQueryCount()
        {
            var input = Console.ReadLine().Split(' ');
            return (int.Parse(input[0]), int.Parse(input[1]));
        }

        public long[] ReadArray(int size)
        {
            return Array.ConvertAll(
                Console.ReadLine().Split(' '),
                long.Parse
            );
        }

        public (int left, int right) ReadQuery()
        {
            var input = Console.ReadLine().Split(' ');
            return (int.Parse(input[0]), int.Parse(input[1]));
        }
    }
}
