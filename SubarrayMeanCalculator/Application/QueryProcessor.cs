using SubarrayMeanCalculator.Services;

namespace SubarrayMeanCalculator.Application
{
    public class QueryProcessor
    {
        private readonly InputParser _inputParser;
        private readonly PrefixSumCalculator _prefixSumCalculator;

        public QueryProcessor(
            InputParser inputParser,
            PrefixSumCalculator prefixSumCalculator)
        {
            _inputParser = inputParser;
            _prefixSumCalculator = prefixSumCalculator;
        }

        public void Process()
        {
            var (arraySize, queryCount) = _inputParser.ReadArrayAndQueryCount();
            long[] array = _inputParser.ReadArray(arraySize);

            long[] prefixSum = _prefixSumCalculator.BuildPrefixSum(array);

            for (int i = 0; i < queryCount; i++)
            {
                var (left, right) = _inputParser.ReadQuery();
                long mean = _prefixSumCalculator.CalculateFloorMean(
                    prefixSum, left, right
                );

                Console.WriteLine(mean);
            }
        }
    }
}
