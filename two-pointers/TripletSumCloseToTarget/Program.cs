using System;


namespace TripletSumCloseToTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(searchTriplet(new int[]{-2, 0, 1, 2}, 2));
        }

        static int searchTriplet(int[] input, int targetSum){

            if( input == null || input.Length < 3){
                throw new ArgumentException("Invalid argument");
            }

            Array.Sort(input);

            int minDifference = int.MaxValue;
            int closestSum = int.MaxValue;

            for(int i = 0; i < input.Length - 2 ; i++){
                int left = i + 1;
                int right = input.Length - 1;

                while(left < right){
                    int tripletSum = input[i] + input[left] + input[right];
                    

                    if( Math.Abs(targetSum - tripletSum) < minDifference ||
                        Math.Abs(targetSum) == Math.Abs(tripletSum) && tripletSum < closestSum ) //this condition is needed for lowest tripletSum; 
                        //there could be more that one solutio, but we want the solution  with the lowest tripletSum
                        {

                            minDifference = Math.Abs(targetSum - tripletSum);
                            closestSum = tripletSum;
                        }

                    if(tripletSum == targetSum){
                        return tripletSum;
                    }else if(tripletSum < targetSum){
                        left++;

                    }else{
                        right--;
                    }

                    

                }
                
            }

            return closestSum;



        }
    }
}
