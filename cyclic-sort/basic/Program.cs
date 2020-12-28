using System;
using System.Collections.Generic;

namespace basic
{
    class Program
    {
        static void Main(string[] args)
        {
             int[] arr = new int[] { 3, 1, 5, 4, 2 };
                sort(arr);
                foreach (int num in arr)
                    Console.Write(num + " ");
                Console.WriteLine();

                //find missing number
                Console.WriteLine(findMissingNumber(new int[] { 2, 0, 3, 1 }));

                var result = findAllMissingNumbers(new int[]{2, 3, 1, 8, 2, 3, 5, 1});
                foreach(var item in result){
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Duplicate number is: " + findDuplicateNumber(new int[]{1, 4, 4, 3, 2 }));

                
                result = finalAllDuplicateNumbers(new int[]{3, 4, 4, 5, 5});

                Console.WriteLine("All duplicate numbers");
                foreach(var item in result){
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                result = finalAllDuplicateAndMissingNumbers(new int[]{3, 1, 2, 5, 2});

                Console.WriteLine("All duplicate & missing numbers");
                foreach(var item in result){
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                Console.WriteLine("missing +ve number is :" + firstMissingPositive(new int[]{-3, 1, 5, 4, 2}));
        }

        public static void sort(int[] nums) {

            if(nums.Length <= 0 ) return;


            int index = 0;

            while(index < nums.Length){
               var nextIndex = nums[index] - 1; //since index starts at zero
               if(nums[index]!= nums[nextIndex]){
                   swap(nums, index,nextIndex);
               }else{
                   index++;
               }
            }


        }

        private static void swap(int[] nums, int index, int nextIndex){
            int temp = nums[index];
            nums[index] = nums[nextIndex];
            nums[nextIndex] = temp;
        }


         public static int findMissingNumber(int[] nums) {
       
            if(nums == null || nums.Length <=0){
                return -1;
            }

            int index = 0;
            while(index < nums.Length){
                //nums are from 0 to n
                //indices are from 0 to n-1
                //Therefore, we will ignore the number ‘n’ as we can’t place it in the array, so => nums[i] < nums.length
                if(nums[index] < nums.Length && nums[index] != nums[nums[index]]){
                    swap(nums, index, nums[index]);
                }else{
                    index++;
                }

              
            }

            //we would have place all the numbers at the correct index expect the last one

              for(int i = 0; i < nums.Length; i++){
                    if( i != nums[i]){
                        return i;
                    }
                }
            //if we reach here then last number is missing
            return nums.Length;
        }
    
          public static List<int> findAllMissingNumbers(int[] nums) {

              int index = 0;
              List<int> result = new List<int>();

              while(index < nums.Length){
                  var nextIndex = nums[index]  - 1;
                  if(nums[index] != nums[nextIndex]){
                      swap(nums,index,nextIndex);
                  }else{
                      index++;
                  }
              }

              for(int i = 0; i < nums.Length ; i++){
                  if(nums[i] != i +1 ){
                      result.Add(i+1);
                  }
              }

              return result;

          }
    
        

          public static int findDuplicateNumber(int[] nums){
              //numbers are from 1 to n
              //index is from o to n-1

              int index = 0;

              while(index < nums.Length ){
                  var nextIndex = nums[index] - 1;
                  if(nums[index] != index + 1){
                    if(nums[index] != nums[nextIndex]){
                        swap(nums,index,nextIndex);

                    }else{
                        //found the duplicate
                        return nums[index];
                    }
                }else{
                    index++;
                }

              }

              return -1;
          }
    
    
         public static List<int> finalAllDuplicateNumbers(int[] nums){

             int index = 0;
             List<int> result = new List<int>();

             while(index < nums.Length){
                 var nextIndex = nums[index] - 1;

                 if(nums[index] != nums[nextIndex]){
                     swap(nums,index,nextIndex);
                 }else{
                     //found the duplicate
                    
                     index++;
                 }
             }

             for(int i = 0; i < nums.Length; i++){
                 if(nums[i] != i + 1){
                     result.Add(nums[i]);
                 }
             }

             return result;
         }
    

         public static List<int> finalAllDuplicateAndMissingNumbers(int[] nums){
             int index = 0;
             while(index < nums.Length){
                 var nextIndex = nums[index] - 1;
                 if(nums[index]!= nums[nextIndex]){
                     swap(nums,index,nextIndex);

                 }else{
                     index++;
                 }
             }

             for(int i = 0; i < nums.Length; i++){
                 if( nums[i] != i + 1){
                     return  new List<int>{nums[i], i+1};
                 }
             }

            return null;

         }
    

         public static int firstMissingPositive(int[] nums){
             //place the numbers on their correct indices and ignore all numbers that are out of the range 
             //of the array (i.e., all negative numbers and all numbers greater than or equal to the length of 
             //the array)

             int index = 0;

             while(index < nums.Length){
                 if(nums[index] > 0 && nums[index] < nums.Length){
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

             for(int i =0; i < nums.Length; i++){
                 if(nums[i] != i + 1){
                     return i+1;
                 }
             }

             return nums.Length + 1;
         }
    }
}
