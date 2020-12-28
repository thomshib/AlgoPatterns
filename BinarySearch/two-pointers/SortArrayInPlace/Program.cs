using System;

namespace SortArrayInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] input = new int[]{2, 2, 0, 1, 2, 0};
           sort(input);
           foreach(var item  in input){
               Console.Write(item + ",");
           }
           Console.WriteLine();
        }

        public static void sort(int[] input) {

            int low = 0;
            int mid = 0;
            int high = input.Length - 1;

            // four ranges
            // 1 to low is the range containing zero
            // low to mid is the range containing one
            // mid to high is the range containing unknwon
            // high to N is the range containing two

            // traverse the array from start to end
            // 1. if the element is zero; swap the element with index low; low++; mid++
            // 2. if the element is one; mid++
            // 3. if the element is two; swap the element with index high; high--; 

            while(mid <= high){
                switch (input[mid]){
                    case 0:
                        swap(input,low,mid);
                        low++;
                        mid++;
                        break;

                    case 1:
                        mid++;
                        break;

                    case 2:
                        swap(input, mid, high);
                        high--;
                        break;

                }
            };

          
        }

        public static void swap(int[] input, int source, int target){
            int temp = input[source];
            input[source] = input[target];
            input[target] = temp;
        }
    }
}
