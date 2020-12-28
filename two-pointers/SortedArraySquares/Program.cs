using System;

namespace SortedArraySquares
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MakeSquares(new int[]{-3, -1, 0, 1, 2});
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        public static int[] MakeSquares(int[] input){

            int left = 0;
            int right = input.Length - 1;
            int highestSquareIndex = input.Length - 1;
            int[] squares = new int[input.Length];


            while(left <= right){
                int leftSquare = input[left] * input[left];
                int rightSquare = input[right] * input[right];

                if(leftSquare > rightSquare){
                    squares[highestSquareIndex] = leftSquare;
                    left++;
                    highestSquareIndex--;

                }else{
                    squares[highestSquareIndex] = rightSquare;
                    right--;
                    highestSquareIndex--;

                }


            }
            return squares;




        }



    }
}
