using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
             List<List<int>> result = findPermutations(new int[] { 1, 3, 5 });
             foreach(var items in result){
                 foreach(var item in items){
                     Console.Write(item + " ");
                 }
                 Console.WriteLine();
             }

             Console.WriteLine("Recursive solution");
             result = generatePermutations(new int[] { 1, 3, 5 });

              foreach(var items in result){
                 foreach(var item in items){
                     Console.Write(item + " ");
                 }
                 Console.WriteLine();
             }

             //string permutations

             Console.WriteLine("String Permutations");
             var strResult = findLetterCaseStringPermutations("ad52");
             foreach(var item in strResult){
                 Console.WriteLine(item);
             }


        }

         public static List<List<int>> findPermutations(int[] nums) {
            List<List<int>> result = new  List<List<int>>();
            
            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int>());

            foreach(var currentNumber in nums){

                int n = queue.Count;
                for(int i = 0; i < n ; i++){
                    var oldPermutation = queue.Dequeue();
                    //create new permutation by adding the current number at every position

                    for(int j = 0; j <= oldPermutation.Count; j++){

                        var newPermutation = new List<int>(oldPermutation);
                        newPermutation.Insert(j,currentNumber);

                        if(newPermutation.Count == nums.Length){
                            result.Add(newPermutation);
                        }else{
                            queue.Enqueue(newPermutation);
                        }
                    }

                }
            }


            return result;
        }
    
          public static List<List<int>> generatePermutations(int[] nums){
              List<List<int>> result = new List<List<int>>();
              List<int> currentPemutation = new List<int>();

              generatePermutationRecursive(nums,result,currentPemutation, 0);
              return result;
          }

        private static void generatePermutationRecursive(int[] nums, List<List<int>> result, List<int> currentPemutation, int index)
        {
            if(index == nums.Length){
                result.Add(currentPemutation);
            }else{

                for(int i = 0; i <= currentPemutation.Count; i++){
                    List<int> newPermutation = new List<int>(currentPemutation);
                    newPermutation.Insert(i,nums[index]);
                    generatePermutationRecursive(nums,result,newPermutation,index + 1);
                }
            }
        }
    
    
        public static List<String> findLetterCaseStringPermutations(String input) {
            List<String> permutations = new List<string>();
            if(input == null){
                return permutations;
            }

            permutations.Add(input);
            //for every character
            for(int i = 0; i < input.Length; i++){
                //process only alphabets
                if(char.IsLetter(input[i])){

                    //take the existing permutation and change case
                    int n = permutations.Count;

                    //for each permutation
                    for(int j = 0; j < n; j++){
                        var charArray = permutations[j].ToCharArray();

                        if(char.IsUpper(charArray[i])){
                            charArray[i] = char.ToLower(charArray[i]);
                        }else{
                            charArray[i] = char.ToUpper(charArray[i]);
                        }
                        permutations.Add(new String(charArray));
                    }
                }
            }

            return permutations;
        }
    
    
    }
}
