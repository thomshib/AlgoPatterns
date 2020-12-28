using System;

namespace basic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(search(new int[] { 4, 6, 10 }, 10));
            Console.WriteLine(search(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5));
            Console.WriteLine(searchNextLetter(new char[]{'a', 'c', 'f', 'h'}, 'f'));
            
            var result = findRange(new int[] { 4, 6, 6, 6, 9 }, 6);
            Console.WriteLine("Range: [" + result[0] + ", " + result[1] + "]");

            ArrayReader reader = new ArrayReader(new int[] { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 });
            Console.WriteLine(searchInfiniteSortedArray(reader,16));

            Console.WriteLine(findMax(new int[] { 1, 3, 8, 12, 4, 2 }));


            Console.WriteLine(searchBitonicArray(new int[] {1, 3, 8, 4, 3}, 4));

        }

        public static int search(int[] arr, int key) {
            int start = 0;
            int end = arr.Length - 1;

            bool isAscending = arr[start] < arr[end];

            while(start <= end){

                int mid = start + (end - start) / 2; //prevent overflow

                if(key == arr[mid]){
                    return mid;
                }

                if(isAscending){

                    if(key > arr[mid]){

                        start = mid + 1;
                    }else{
                        end = mid - 1;
                    }
                }else{
                    //descending order
                    if(key > arr[mid]){
                        end = mid - 1;
                    }else{
                        start = mid + 1;
                    }
                }
            }
            

            return -1; //element not founds
        }

    
         public static int searchCeilingOfANumber(int[] arr, int key) {
           
           int start = 0;
           int end = arr.Length - 1;

           if (key > arr[arr.Length  - 1]){
               //key is bigger than biggest element of the array
               return -1;
           }

           while(start <= end){

               int mid = start + (end - start) / 2;

               if(arr[mid] == key){
                   return mid;
               }else if(key > arr[mid]){
                   start = mid = 1;
               }else{
                   end = mid - 1;
               }
           }
            return -1;
        }
    
    
         public static char searchNextLetter(char[] letters, char key) {

             int n = letters.Length;

             if( key > letters[n-1] || key < letters[0]){
                 return letters[0];
             }

             int start = 0;
             int end = n - 1;

             while(start <= end){

                 int mid = start + (end - start) / 2;

                 if( key < letters[mid]){
                     end = mid - 1;
                 }else{
                    start = mid + 1;
                 }

                 
             }

             //if the key matches the last letter, we need to return letter[0] as it is a circulat list

             return letters[start % n]; 

         }

    
         public static int[] findRange(int[] arr, int key) {
            int[] result = new int[] { -1, -1 };

            result[0] = search(arr, key, false);
            if(result[0] != -1){
                result[1] = search(arr,key, true);
             }
        


            return result;
        }

        private static int search(int[] arr, int key, bool findMaxIndex)
        {
            int keyIndex = -1;
            int start = 0;
            int end = arr.Length - 1;
            while(start <= end){
                int mid = start + (end - start) / 2;

                if(key > arr[mid]){
                    start = mid + 1;
                }else if(key < arr[mid]){

                    end = mid - 1;
                }else{
                    //key == arr[mid]
                    keyIndex = mid;

                    if(findMaxIndex){
                        start = mid + 1; //seach ahead to find the last index
                    }else{
                        end = mid - 1;  //seach behind to find the first index
                    }
                }
            }

            return keyIndex;
        }

         public static int searchInfiniteSortedArray(ArrayReader reader, int key){
              
              //find the bounds first
              int start = 0;
              int end = 1;

              while(key > reader.get(end)){
                  int newStart = end + 1;
                  end += 2 * (end - start + 1); //double the bound
                  start = newStart;
              }

              return binarySearch(reader, start ,end, key);

         }

        private static int binarySearch(ArrayReader reader, int start, int end, int key)
        {
            while(start <= end){
                
                int mid = start + (end - start) / 2;

                if(key > reader.get(mid)){
                    start = mid + 1;
                }else if( key < reader.get(mid)){
                    end = mid -1;
                }else{
                    return mid;
                }
            }
            return - 1;
        }
    
    
        public  static int findMax(int[] arr){
            int start = 0;
            int end = arr.Length - 1;

            while(start < end){
                int mid = start + (end - start) / 2;

                if(arr[mid] > arr[mid+1]){ //move to the first part
                    end = mid;

                }else{
                    start = mid + 1;
                }
            }

            //at the end of while loop ; start == end

            return arr[start];
        }
    
    
        public static int searchBitonicArray(int[] arr, int key) {
           
           int maxIndex = findMaxIndex(arr);

           int keyIndex = binarySearch(arr,key, 0, maxIndex);

           if(keyIndex != -1) return keyIndex;

           return(binarySearch(arr,key,maxIndex + 1, arr.Length - 1));
        }


        public static int binarySearch(int[] arr, int key, int start, int end)
        {
             while(start <= end){

                 bool isAscending = arr[start] < arr[end];

                 int mid = start  + (end - start) / 2;

                 if (key == arr[mid]){
                     return mid;
                 }

                 if(isAscending){

                     if(key > arr[mid]){
                         start = mid + 1;
                     }else{
                         end = mid - 1;
                     }

                 }else{
                      if(key > arr[mid]){
                          end = mid - 1;
                         
                     }else{
                         start = mid + 1;
                     }
                 }

             }

            return -1;
        }


        private  static int findMaxIndex(int[] arr){

            int start = 0;
            int end = arr.Length - 1;

            while(start < end){

                int mid = start + ( end - start) / 2;

                if(arr[mid] > arr[mid+1]){
                    end = mid;
                }else{
                    start = mid + 1;
                }

            }

            return start;


        }


    
    }
}
