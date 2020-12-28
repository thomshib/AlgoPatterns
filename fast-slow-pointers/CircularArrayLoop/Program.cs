using System;

namespace CircularArrayLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(loopExists(new int[] { 1, 2, -1, 2, 2 }));
            Console.WriteLine(loopExists(new int[] { 2, 2, -1, 2 }));
            Console.WriteLine(loopExists(new int[] { 2, 1, -1, -2 }));

        }

          public static bool loopExists(int[] input) {
           
           for(int i = 0;  i< input.Length ; i++){

            int slow = i;
            int fast = i;
            bool isForward = input[i] >=0;
            do{
                slow = findNextIndex(input, slow,isForward); //move one step
                fast = findNextIndex(input, fast, isForward); //move one step

                if(fast != -1){
                    fast = findNextIndex(input, fast, isForward); //move one more step
                }
            
            }while(slow != -1 && fast != -1 && slow != fast);

            if(slow != -1 && slow == fast){
                return true;
            }

           }
            return false;
        }

        private static int findNextIndex(int[] input, int currentIndex, bool isForward)
        {
            bool direction = input[currentIndex] >= 0;
            if(direction != isForward) {
                return -1;
            }

            int nextIndex = (currentIndex + input[currentIndex]) % input.Length;
            if(nextIndex < 0){
                nextIndex = nextIndex + input.Length;  //wrap around for -ve numbers

            }

            //one element cycle; return -1
            if(currentIndex == nextIndex){
                nextIndex =  -1;
            }

            return nextIndex;


        }
    }
}
