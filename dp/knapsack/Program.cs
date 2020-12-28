using System;

namespace knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] profits = {1, 6, 10, 16};
            int[] weights = {1, 2, 3, 5};
            int maxProfit = solveKnapsack(profits, weights, 7);
            Console.WriteLine("Total knapsack profit Recursive ---> " + maxProfit);

           Console.WriteLine();
    
            Console.WriteLine("Total knapsack profit Dynamic Programming OIptimizwed is  ---> " + solveKnapsackDynamicProgrammingOptimised(profits,weights,7));
            
        }

         public static int solveKnapsack(int[] profits, int[] weights, int capacity) {
             int[,] dp = new int[profits.Length,capacity + 1];
             return knapsackRecursive(dp, profits,weights,capacity,0);
         }

        private static int knapsackRecursive( int[,] dp, int[] profits, int[] weights, int capacity, int index)
        {
           //base case
           if(capacity <=0 || index >= profits.Length){
               return 0;


           }
           if(dp[index,capacity] != 0){
               return dp[index,capacity];
           }

           int profit1 = 0;
           //include the current element
           if(weights[index] <= capacity){
               profit1 = profits[index] + knapsackRecursive(dp,profits,weights, capacity - weights[index],index + 1);
           }
        
            //do not include the element

            int profit2 =knapsackRecursive(dp,profits,weights,capacity,index + 1);

            dp[index,capacity] = Math.Max(profit1 , profit2);

            return dp[index,capacity];
        
        
        }

        public static int solveKnapsackDynamicProgramming(int[] profits, int[] weights, int capacity) {

            //f or each item at index ‘i’ (0 <= i < items.length) and capacity ‘c’ (0 <= c <= capacity), we have two options:
            // 1. Exclude the item at index ‘i’. In this case, we will take whatever profit we get from the sub-array excluding this item => dp[i-1][c]
            // 2. Include the item at index ‘i’ if its weight is not more than the capacity. In this case, we include its profit plus 
            //     whatever profit we get from the remaining capacity and from remaining items => profit[i] + dp[i-1][c-weight[i]]

            // Dynamic programming formula is
            //dp[i,c]  = Max( dp[i-1][c] ,  profit[i] + dp[i -1, c - weight[i]   )


            if(capacity <=0 || profits.Length == 0 || profits.Length != weights.Length){
                return 0;
            }

            int n = profits.Length;

             int[,] dp = new int[n,capacity + 1];
             

            //populate capacity 0 with profit 0; initial first col

            for(int i = 0; i < n;i++){
                dp[i,0] = 0;
            }

            //initialize first row
            //if we have only one weight; initialize with profit[0]

            for(int c = 0; c <= capacity; c++ ){
                if(weights[0] <= c)
                    dp[0,c] = profits[0];
            }

            //process the rest of the items n
            for(int i = 1; i < n; i++){
                for(int c = 1; c <= capacity; c++){
                    int profit1 = 0;
                    int profit2 = 0;

                    //include the item; if the capacity allows it
                    if(weights[i] <= c){
                        profit1 = profits[i] + dp[i-1,c-weights[i]];
                    }

                    //exclude the item
                    profit2 = dp[i-1,c];

                    //take the max

                    dp[i,c] = Math.Max(profit1,profit2);
                }
            }
            printSelectedItems(dp,weights,profits,capacity);

            return dp[n - 1, capacity];


         }

         private static void printSelectedItems(int[,] dp, int[] weights, int[] profits, int capacity){

             Console.WriteLine("Selected weights");
             int totalProfits = dp[weights.Length - 1,capacity];

             for(int i = weights.Length - 1 ; i > 0 ; i--){
                 //does't come up from top
                 if(totalProfits != dp[i-1, capacity]){ 
                    Console.Write(" " + weights[i]);
                    
                    capacity = capacity - weights[i];
                    totalProfits = totalProfits - profits[i];
                 }
             }

             if(totalProfits != 0){
                 Console.Write(" " + weights[0]);
             }

         }




        // 
        public static int solveKnapsackDynamicProgrammingOptimised(int[] profits, int[] weights, int capacity) {

            if(capacity <=0 || profits.Length ==0 || profits.Length != weights.Length){
                return 0;
            }

            //we only two rows to find the solution
            //we use i%2 instead of i and (i-1) %2 instead of i-1

            int[,] dp = new int[2,capacity + 1];

            int n = profits.Length;

            //initialize rows and cols

            //initialize first col as zero as capacity is zero

            for(int i = 0; i < 2; i++){
                dp[i,0] = 0;
            }

            //intialize first row with profit if capacity allows
            for(int c = 0; c <= capacity; c++){
                if(weights[0] <= c){
                    dp[0,c] = profits[0];
                }
            }

            for(int i = 1; i < n ; i++){
                for(int c = 1 ; c <= capacity; c++){
                    int profit1 = 0;
                    int profit2 = 0;
                    //include the item if the capacity allows it
                    if(weights[i] <= c){
                     profit1 = profits[i] + dp[(i-1)%2, c - weights[i]];
                    }

                    //exlude the item
                    profit2 = dp[(i-1)%2,c];

                    dp[i%2,c] = Math.Max(profit1, profit2);
                }
            }

            return dp[(n-1)%2 , capacity];


        }   
    }
}
