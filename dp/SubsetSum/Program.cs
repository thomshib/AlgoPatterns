using System;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] num = {1, 1, 2, 3};
           Console.WriteLine(countSubsets(num, 4));
        Console.WriteLine(countSubsetsDP(num, 4));
        }

        static int countSubsets(int[] nums, int sum) {

            int?[,] dp = new int?[nums.Length, sum + 1];
            
            return countSubsetsRecursive(dp, nums, sum ,0);
        }

        private static int countSubsetsRecursive(int?[,] dp ,int[] nums, int sum, int index)
        {
            
            if(sum == 0){
                return 1;
            }

            if( index >= nums.Length){
                return 0;
            }

            if( dp[index, sum] == null){

            int sum1 = 0;
            //include the current element if it is less than sum

            if(nums[index] <= sum){
                sum1 = countSubsetsRecursive(dp, nums, sum - nums[index], index + 1);
            }

            //exclude the current element
            int sum2 = countSubsetsRecursive(dp,nums, sum, index + 1);

            dp[index, sum] = sum1+ sum2;
           

            }
             return dp[index, sum] ?? -1;

        }
    
    
         static int countSubsetsDP(int[] nums, int sum) {

             int n = nums.Length;
             int[,] dp = new int[n, sum + 1];

             //initialize sum 0 columns
             for(int i = 0; i < n; i++){
                 dp[i,0] = 1;
             }

            //initialize first row with  nums[0] if it can be accomdated by the sum value in the col
            for(int c = 1; c <= sum; c++ ){
                if(nums[0] == c){
                    dp[0,c] = 1;
                }else{
                    dp[0,c] = 0;
                }
            } 

            //process all subsets

            for(int i = 1; i < n; i++){
                for( int c = 1; c<= sum; c++){

                    //exclude the number
                    dp[i,c] = dp[i-1,c];

                    //include the number
                    if(nums[i] <= c){

                        dp[i,c] += dp[i-1 , c - nums[i]];
                    }
                }
            }

            return dp[n-1,sum];

         }
    
    
    }
}
