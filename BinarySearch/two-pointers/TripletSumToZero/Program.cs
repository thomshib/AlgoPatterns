using System;
using System.Collections.Generic;

namespace TripletSumToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = searchTriplets(new int[]{-3, 0, 1, 2, -1, 1, -2});
            Console.WriteLine();
            foreach(var items in result){
                foreach (var item in items)
                {
                    Console.Write(item + ",");       
                }
                Console.WriteLine();
            }
        }

        public static List<List<int>> searchTriplets(int[] input) {
            Array.Sort(input);
            var triplets = new List<List<int>>();

            for(int i = 0; i < input.Length - 2; i++){
                //skip element to avoid duplicates
                if( i > 0 && input[i] == input[i-1]) continue;

                SearchPair(input, -input[i], i + 1, triplets);
            }

            return triplets;



        }

        private static void SearchPair(int[] input, int targetSum, int left, List<List<int>> triplets)
        {
            int right = input.Length - 1;
            while(left < right){
                int currentSum = input[left] + input[right];

                if( currentSum == targetSum){
                    triplets.Add(new List<int>{-targetSum, input[left], input[right]});
                    left++;
                    right--;
                    //skip same element
                    while(left < right && input[left] == input[left -1]) left++;
                     while(left < right && input[right] == input[right + 1]) right--;


                }else if( currentSum < targetSum){
                    left++;
                }else{
                    right--;
                }
            }

        }
    }
}
