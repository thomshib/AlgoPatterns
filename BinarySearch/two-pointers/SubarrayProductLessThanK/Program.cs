using System;
using System.Collections.Generic;

namespace SubarrayProductLessThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findCountSubarrays(new int[]{5, 3, 2},16));

            var result = findSubarrays(new int[]{ 2, 5, 3, 10},30);
            foreach(var items in result){
                Console.Write("{");
                foreach(var item in items){
                    Console.Write(item);
                    Console.Write(",");
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }

         public static int  findCountSubarrays(int[] input, int target) {

             int windowStart = 0;
             int product = 1;
             int count = 0;

             for(int windowEnd = 0; windowEnd < input.Length; windowEnd++  ){

                //add the next element
                 product *= input[windowEnd];

                 //two cases on adding a new element x to the sliding window

                //case 1: p * x >= target; move the sliding window
                while(windowStart < windowEnd && product >= target){
                    //remove the element going out from the product
                    product /= input[windowStart];
                    windowStart++;
                } 



                 //case 2: p * x < target; # of subarray is 1 + windowEnd - windowStart
                 //i.e (new element subarray)  + (adding this new element to all subarrays in the window)

                 if(product < target){
                     count += 1 + windowEnd - windowStart;
                 }

             }

             return count;

         }

        public static List<List<int>>  findSubarrays(int[] input, int target) {

             int windowStart = 0;
             int product = 1;
             
             List<List<int>> result = new List<List<int>>();

             for(int windowEnd = 0; windowEnd < input.Length; windowEnd++  ){

                //add the next element
                 product *= input[windowEnd];

                 //two cases on adding a new element x to the sliding window

                //case 1: p * x >= target; move the sliding window
                while(windowStart < input.Length && product >= target){
                    //remove the element going out from the product
                    product /= input[windowStart];
                    windowStart++;
                } 



                 //case 2: p * x < target; # of subarray is 1 + windowEnd - windowStart
                 //i.e (new element subarray)  + (adding this new element to all subarrays in the window)

                // all subarrays from left to right will have a product less than the target too; to avoid
                // duplicates, we will start with a subarray containing only arr[right] and then extend it
                List<int> tempList = new List<int>();

                for(int i = windowEnd ; i >= windowStart; i--){
                    tempList.Insert(0,input[i]);
                    result.Add(new List<int>(tempList));

                }

                

             }

             return result;

         }

    }
}
