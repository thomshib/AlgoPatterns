using System;

namespace NextInterval
{

class Interval {
        public int start = 0;
        public int end = 0;

        Interval(int start, int end) {
            this.start = start;
            this.end = end;
        }
}

    class Program
    {
        static void Main(string[] args)
        {
            
        }

         public static int[] findNextInterval(Interval[] intervals) {
             int n = intervals.Length;

             if(n == 0) return null;

             int[] result = new int[n];
             


         }
    }
}
