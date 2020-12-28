using System;

namespace MissingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //  int[] arr = new int[] { 1, 5, 2, 6, 4 };
            // Console.WriteLine("Missing number is: " + findMissingNumber(arr));
            // Console.WriteLine("Non Duplciated  number is: " + findSingleNumber(new int[]{1, 4, 2, 1, 3, 2, 3}));

            // var result = findTwoNumbers(new int[]{1, 4, 2, 1, 3, 5, 6, 2, 3, 5 });
            // Console.WriteLine("Two non duplciate numbers are ");
            // foreach(var num in result){
            //     Console.Write( num + " ");
            // }
            // Console.WriteLine();

            // Console.WriteLine("complement of Base 10 is " + bitwiseComplement(8));

            var output = flipAndInvertImage(new int[][]{
                new int[]{1, 2, 3}, 
                new int[]{4, 5, 6}, 
                new int[]{7, 8, 9} 
            });
        }

         public static int findMissingNumber(int[] arr) {

             int n = arr.Length + 1;

             int x1 = 1;


             for(int i = 2; i <= n; i++ ){
                 x1 = x1 ^ i;
             }

             int x2 = arr[0];

             for(int i = 1; i < n - 1; i++ ){
                 x2 = x2 ^ arr[i];
             }

            return  x1 ^ x2;

         }

         public static int findSingleNumber(int[] arr) {
            
            int num = 0;

            for(int i = 0; i < arr.Length; i++){
                num = num ^ arr[i];
            }
            return num;
        }

         public static int[] findTwoNumbers(int[] arr){

             int n1xn2 = 0;

             //get the XOR of all the elements
             foreach(var num in arr){
                 n1xn2 = n1xn2 ^ num;
             }

             //we got n1 and n2
             //find the differrrence in the bit to separte n1 and n2
             int rightMostBitSet = 1;

            while( (rightMostBitSet & n1xn2) == 0){
                rightMostBitSet = rightMostBitSet << 1;
            }

            int num1 = 0;
            int num2 = 0;

            foreach(var num in arr){

                if ( ( num & rightMostBitSet) != 0){
                    num1 = num1 ^ num; 
                }else{
                    num2 = num2 ^ num;
                }
            }

             return new int[]{num1, num2};



         }
    
    
         public static int bitwiseComplement(int n) {
           
            //calculte the # of bits

            int bitcount = 0;

            int num = n;
            while(num > 0){
                bitcount++;
                num = num >> 1;
            }

            int all_bits_set = (int) Math.Pow(2, bitcount) - 1;

            return n ^ all_bits_set;



        }
    
    
        public static int[][] flipAndInvertImage(int[][] arr) {
            
            int n = arr[0].Length;
            int mid = (n + 1) / 2;

            for(int i = 0; i < mid; ++i){
                Console.WriteLine("arr[i] = " + i + " value = " + arr[0][i]);
                int index = mid - 1 - i;
                Console.WriteLine("arr[mid - 1 -i]:" +  index.ToString() + " value = " + arr[0][mid - 1 -i]);
            }


            return arr;
        }
    
    
    }
}
