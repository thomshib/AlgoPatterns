using System;

namespace TripletWithSmallerSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(searchTriplets(new int[]{-1, 0, 2, 3}, 3));
        }

        public static int searchTriplets(int[] input, int target) {

            if(input==null || input.Length < 3){
                throw new ArgumentException("Inalid Arguments");
            }

            int count = 0;
            Array.Sort(input);

            for(int i = 0; i < input.Length - 2; i++ ){

                count += searchPair(input, target - input[i], i + 1);

            }

            return count;



        }

        private static int searchPair(int[] input, int target, int left)
        {
            int right = input.Length - 1;
            int count = 0;
            while(left < right){
                if(input[left] + input[right] < target){
                    //since input[right] >= input[left]
                    //we can replace any # between left and right to get a sum lower than the target sum
                    count += right - left;
                    left++;
                    
                }else{
                    right--;
                }
            }

            return count;
        }
    }
}
