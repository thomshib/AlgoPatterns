using System;

namespace PartitionSet
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 2, 3, 4 };
            Console.WriteLine(canPartition(num));
            Console.WriteLine(canPartitionDP(num));

            //--------------------------------

            num = new int[]{1, 2, 3, 9};
            Console.WriteLine("partition the set into two subsets with minimum difference ");
            Console.WriteLine(canPartitionTwoSubsSets(num));
             Console.WriteLine(canPartitionTwoSubsSetsDP(num));

            
        }

         public static bool canPartition(int[] nums) {
             int sum = 0;

             foreach(var item in nums){
                 sum += item;
             }

             if(sum%2 != 0) return false; //can't partition odd sum into two

             bool?[,] dp = new bool?[nums.Length, sum/2 + 1];

             return canPartitionRecursive(dp,nums, sum/2 , 0);

         }

        private static bool canPartitionRecursive(bool?[,] dp, int[] nums, int sum, int index)
        {
            //base case

            if(sum == 0){
                return true;
            }

            if(index >= nums.Length){
                return false;
            }

            //if we have not seen this subproblem

            if(dp[index,sum] == null){

                //include the current Number
                if(nums[index] <= sum){
                    if(canPartitionRecursive(dp,nums,sum - nums[index],index + 1 )){
                        dp[index,sum] = true;
                        return true;
                    }
                }

                //exlcude the current number

                dp[index,sum] = canPartitionRecursive(dp,nums, sum, index + 1);
            }

            return dp[index, sum] ?? false;


        }
    
         public static bool canPartitionDP(int[] nums) {
             int sum = 0;

             foreach(var item in nums){
                 sum += item;
             }

             sum = sum / 2;
             int n = nums.Length;

             // DP logic 
             // 0 <= i < nums.length;  0 <= s <= s/2
             // 1. include the number if its value is not more than s;  
             //     in this case find subset to get the remaining sume dp[i-1][s - num[i]]
             // 2. Exclude the number; find s from the subset excluding this numberr
             //     dp[i-1][s]

            bool[,] dp = new bool[n, sum + 1];

            // sum = 0 columns ; can be found with an empty se
            for(int i = 0; i < n; i++){
                dp[i,0] = true;
            }

            //with only one number; we can form a subset when num is equal to the sum
            for(int s = 0; s <= sum; s++){
                dp[0,s] = (nums[0] == s) ? true: false;
            }

            for(int i = 1; i < n; i++){
                for(int s = 1; s <= sum ; s++ ){

                    //include the number
                    if(nums[i] <= s){
                        dp[i,s] = dp[i-1, s - nums[i] ];
                    }else if ( dp[i-1,s]) {
                        //exclude the number
                        dp[i,s] = dp[i-1,s];
                    }
                }
            }

            return dp[n-1,sum];

    
    }

        public static int canPartitionTwoSubsSets(int[] nums) {

            return canPartitionRecusiveTwoSubsSets(nums, 0,0,0);
        }

        private static int canPartitionRecusiveTwoSubsSets(int[] nums, int index, int sum1, int sum2)
        {
            if(index == nums.Length){
                return Math.Abs(sum1 - sum2);
            }

            int diff1 = canPartitionRecusiveTwoSubsSets(nums, index + 1, sum1 + nums[index], sum2);
            int diff2 = canPartitionRecusiveTwoSubsSets(nums, index+1, sum1 , sum2 + nums[index]);

            return Math.Min(diff1,diff2);
        }
    

     public static int canPartitionTwoSubsSetsDP(int[] nums) {

         //calculate the cumulative sum
         int sum = 0;
         foreach(var item in nums){
             sum += item;
         }

         int halfSum = sum / 2;
         int n = nums.Length;

         bool[,] dp = new bool[n, halfSum + 1];

         //initialize sum=0 columns

         for(int i = 0; i < n; i++){
             dp[i,0] = true;
         }

         //initialize the first row, we have one number, include it if it is less than s

         for(int s = 1; s <= halfSum; s++){
             if( nums[0] == s){
                 dp[0,s] = true;
             }else{
                  dp[0,s] = false;
             }
         }

        //process the rest of the rows

        for(int i = 1; i < n; i++){
            for(int s= 1; s <= halfSum; s++){

                //exlcude the number i
               
                if(dp[i-1,s]){
                    dp[i,s] = dp[i-1,s ];
                }else if( s >= nums[i]){
                    
                    dp[i,s] = dp[i-1,s - nums[i]];
                }

               
            }
        }

        int sum1 = 0;

        //find the  first true value in  the last row in reverse
         for(int s = halfSum; s >= 0; s--){
            

             if(dp[n-1,s] == true){
                 sum1 = s;
                 break;
             }
         }

         int sum2 = sum - sum1;

         return Math.Abs(sum1 - sum2);

           
    }

}

}
