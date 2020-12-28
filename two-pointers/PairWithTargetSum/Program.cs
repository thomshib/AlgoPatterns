using System;
using System.Collections.Generic;

namespace PairWithTargetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // var result  = Search(new int[]{2, 5, 9, 11}, 11);
            // foreach (var item in result)
            // {
            //     Console.WriteLine(item);
            // };

            Console.WriteLine(RemoveDuplicates(new int[]{2, 2, 2, 11}));
        }


          public static int[] Search(int[] input, int targetSum) {
          
              int left = 0;
              int right = input.Length - 1;
              List<int> result = new List<int>();
              int currentSum = 0;

              while (left < right){
                  currentSum = input[left] + input[right];
                  if(currentSum == targetSum){
                      return new int[]{left,right};

                  }else if(targetSum > currentSum){
                      left++;
                  }else{
                      right--;
                  }

              }

              return new int[] {-1,-1};
          
          }
    
         public static int RemoveDuplicates(int[] input) {

             int nextNonDiplicateIndex = 1;
             for(int i = 1; i < input.Length ; i++){
                 if(input[nextNonDiplicateIndex - 1] != input[i]){
                     input[nextNonDiplicateIndex] = input[i];
                     nextNonDiplicateIndex++;
                 }
             }

            return nextNonDiplicateIndex;


            }

             

        

    
    
    }
}
