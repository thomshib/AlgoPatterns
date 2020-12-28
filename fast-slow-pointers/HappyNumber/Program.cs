using System;

namespace HappyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(find(12));
            Console.WriteLine(find(23));

        }

         public static bool find(int num) {

             int slow = num;
             int fast = num;
             do{
                 slow = findSquareSum(slow);                //move one step
                 fast = findSquareSum(findSquareSum(fast)); //move two step

             }while(fast != slow);  //found a cycle
          
                
            return slow == 1;  //see if cycle is stuck at 1
        }

        private static  int findSquareSum(int num){
            int sum = 0;
            int digit = 0;
            while(num > 0){
                digit = num % 10;
                sum += digit * digit;
                num /= 10;
            }
            return sum;
        }
    }
}
