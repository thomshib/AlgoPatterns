using System;
using System.Collections.Generic;

namespace FindSubsets
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> result = findSubsets(new int[] { 1, 3 });

            foreach(var items in result){
                Console.Write("{");
                foreach(var item in items){
                    Console.Write(item + " ") ;
                }
                Console.Write("}");
                Console.WriteLine();
            }


             result = findSubsetsWithoutDuplicates(new int[] { 1, 3, 3 });

            foreach(var items in result){
                Console.Write("{");
                foreach(var item in items){
                    Console.Write(item + " ") ;
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }

         public static List<List<int>> findSubsets(int[] nums) {
            List<List<int>> subsets = new List<List<int>>();

            //start by creating empty subset
            subsets.Add(new List<int>());
            foreach(var currentNumber in nums){

                //create new subsets from exisiting sets
                int n = subsets.Count;

                for(int i = 0; i < n; i++){
                    //create a new subset from exisiting subset and insert the current element to it
                    var set = new List<int>(subsets[i]);
                    set.Add(currentNumber);
                    subsets.Add(set);
                } 
            }
            
            return subsets;
        }

            public static List<List<int>> findSubsetsWithoutDuplicates(int[] nums) {

                List<List<int>> subsets = new List<List<int>>();

                Array.Sort(nums);
                int startIndex = 0;
                int endIndex = 0;

                subsets.Add(new List<int>());

                for(int i = 0; i < nums.Length; i++)
                {
                    startIndex = 0;

                    if(i > 0 && nums[i] == nums[i-1]){
                        //reset startIndex to previous steps end
                        startIndex = endIndex + 1;
                    }

                    endIndex = subsets.Count - 1;

                    for(int j = startIndex; j<= endIndex; j++){
                        //create a new subset
                        List<int> set = new List<int>(subsets[j]);
                        set.Add(nums[i]);
                        subsets.Add(set);

                    }
                }

                return subsets;

            }
    }
}
