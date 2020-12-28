using System;

namespace ShortestWindowSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sort(new int[]{1, 3, 2, 0, -1, 7, 10}));
        }


         public static int sort(int[] input) {

             int low = 0;
             int high = input.Length - 1;

             //find the first number out of order from the begining

             while(low < input.Length - 1 && input[low] <= input[low+1]){
                 low++;
             }

             if(low == input.Length - 1){
                 return 0; //array is sorted
             }

              //find the first number out of order from the end

              while(high > 0 && input[high] >= input[high - 1] ){
                  high--;
              }

              //find the min and max of the subarray
              int min = int.MaxValue;
              int max = int.MinValue;
              for(int k = low; k <= high; k++){
                  max = Math.Max(max, input[k]);
                  min = Math.Min(min, input[k]);

              }

              //extend the subarray to include elements higher than the sub array min
              while(low > 0 && input[low - 1 ] > min){
                  low--;
              }

             //extend the subarray to include elements lower than the sub array max
              while(high < input.Length - 1 && input[high + 1 ] < max){
                  high++;
              }

            return high - low + 1;

         }
    }
}
