namespace SubarrayMeanCalculator.Services
{
    public class PrefixSumCalculator
    {
        public long[] BuildPrefixSum(long[] array)
        {
            long[] prefixSum = new long[array.Length + 1];
            prefixSum[0] = 0;

            for (int i = 1; i <= array.Length; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + array[i - 1];
            }

            return prefixSum;
        }

        public long CalculateFloorMean(long[] prefixSum, int left, int right)
        {
            long sum = prefixSum[right] - prefixSum[left - 1];
            int count = right - left + 1;

            return sum / count;
        }
    }
}
