using SubarrayMeanCalculator.Application;
using SubarrayMeanCalculator.Services;

namespace SubarrayMeanCalculator
{
    class Program
    {
        static void Main()
        {
            var inputParser = new InputParser();
            var prefixSumCalculator = new PrefixSumCalculator();

            var queryProcessor = new QueryProcessor(
                inputParser,
                prefixSumCalculator
            );

            queryProcessor.Process();
        }
    }
}
