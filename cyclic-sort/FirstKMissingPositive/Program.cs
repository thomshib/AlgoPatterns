using System;
using System.Collections.Generic;

namespace FirstKMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            var missingNumbers = findNumbers(new int[] { 3, -1, 4, 5, 5 }, 3);
            foreach(var item in missingNumbers){
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static List<int> findNumbers(int[] nums, int k) {

            int index = 0;

            while(index < nums.Length){
                
                if(nums[index] > 0 && nums[index] <= nums.Length){
                    var nextIndex = nums[index] - 1;
                    if(nums[index] != nums[nextIndex]){
                        swap(nums,index,nextIndex);
                    }else{
                        index++;
                    }
                }else{
                    index++;
                }
            }

            List<int> missingNumbers = new List<int>();
            HashSet<int> extraNumbers = new HashSet<int>();

            for(int i = 0; i < nums.Length && missingNumbers.Count < k; i++){

                if(nums[i] != i + 1){
                    missingNumbers.Add(i+1);
                    extraNumbers.Add(nums[i]);
                }
            }

            for(int i = 1; missingNumbers.Count< k ; i++){
                int candidateNumber = i + nums.Length;
                if(!extraNumbers.Contains(candidateNumber)){
                    missingNumbers.Add(candidateNumber);
                }
            }

            return missingNumbers;



        }

        private static void swap(int[] nums, int index, int nextIndex){
            int temp = nums[index];
            nums[index] = nums[nextIndex];
            nums[nextIndex] = temp;
        }
    }
}
