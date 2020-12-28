using System;

namespace SearchRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(search(new int[] { 10, 15, 1, 3, 8 }, 15));
             Console.WriteLine(countRotations(new int[] { 10, 15, 1, 3, 8}));
        }

         public static int search(int[] arr, int key) {

             int start = 0;
             int end = arr.Length - 1;

             while(start <= end){

                 int mid = start + (end - start) / 2;

                 if(arr[mid] == key) return mid;


                //determine the left half or right half for descending order
                if( arr[start] <= arr[mid]){
                    //left side is in ascending order
                    if(key >= arr[start] && key< arr[mid]){
                        end = mid - 1;
                    }else{
                        start = mid + 1;
                    }
                }else{
                    //right side is in ascending order
                    if(key > arr[mid] && key <= arr[end]){
                        start = mid + 1;
                    }else{
                        end = mid - 1;
                    }
                }


             }

             return -1;

         }
    
    
         public static int countRotations(int[] arr) {
             int start = 0;
             int end = arr.Length - 1;

             while(start < end){

                 int mid = start + (end - start) / 2;

                 //find the smallest element; smallest element is the
                 // only element in the given array which is smaller than its previous element. 

                 if( mid > start && arr[mid] < arr[mid - 1]  ){
                     return mid;
                 } 

                 if(mid < end  && arr[mid] > arr[mid + 1]){
                     return mid + 1;
                 }

                 //find ascending parts
                 if(arr[start] < arr[mid]){
                     //left part is in ascending order and sorted; pivot will be on right side
                     start = mid + 1;
                 }else{
                     end = mid - 1;
                 }


             }
        
            return 0; //array has not been rotated 
        }
    
    
    
    }
}
