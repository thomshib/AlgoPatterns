using System;

namespace MinSize_SubArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = MinSubArraySum.findArraySum(7, new int[]{2, 1, 5, 2, 3, 2});
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
