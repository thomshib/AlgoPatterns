using System;

namespace max_sum_array
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = AverageOfSubarrayOfSizeK.findAverages(5, new int[]{1, 3, 2, 6, -1, 4, 1, 8, 2});
            Array.ForEach(result, Console.WriteLine);
            Console.ReadLine();
        }
    }
}
