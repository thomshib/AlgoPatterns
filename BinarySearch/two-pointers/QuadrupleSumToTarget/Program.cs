using System;
using System.Collections.Generic;

namespace QuadrupleSumToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = searchQuadruplets(new int[]{4, 1, 2, -1, 1, -3 },1);
            foreach(var items in result){
                Console.Write("{");
                foreach(var item in items){
                    Console.Write(item + ",");
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }

         public static List<List<int>> searchQuadruplets(int[] input, int target) {
             Array.Sort(input);
             List<List<int>> qadruplets = new List<List<int>>();

             for(int i = 0; i < input.Length - 3; i++){
                 if(i > 0 && input[i] == input[i-1]) continue; //remove duplcates

                 for(int j = i+1; j < input.Length -2; j++){
                    if( j > i+1 && input[j] == input[j-1]) continue; //remove duplicates

                    searchPairs(input, target, i , j, qadruplets);
                 }
             }

             return qadruplets;

         }

        private static void searchPairs(int[] input, int target, int first, int second, List<List<int>> qadruplets)
        {
            int left = second + 1;
            int right = input.Length - 1;

            while(left < right){
                int sum = input[first] + input[second] + input[left] + input[right];
                if ( sum == target){
                    qadruplets.Add(new List<int>{input[first] , input[second] , input[left] , input[right]});
                    left++;
                    right--;
                    while(left < right && input[left] == input[left - 1]) left++;
                    while(left < right && input[right] == input[right + 1]) right--;

                }else if (sum < target){
                    left++;
                }else{
                    right--;
                }
            }

        }
    }
}
