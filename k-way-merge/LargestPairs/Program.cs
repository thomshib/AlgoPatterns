using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataStrcutures;

namespace LargestPairs
{

    class Pairs:IComparable<Pairs>{
        public int value1;
        public int value2;
        public Pairs(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public int Sum{
            get{return value1 + value2;}
        }

        public int CompareTo(Pairs other)
        {
            return (this.Sum.CompareTo(other.Sum));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] l1 = new int[] { 9, 8, 2 };
            int[] l2 = new int[] { 6, 3, 1 };
            List<int[]> result = findKLargestPairs(l1, l2, 3);
            Console.WriteLine("Pairs with largest sum are: ");
            foreach (int[] pair in result)
                Console.WriteLine("[" + pair[0] + ", " + pair[1] + "] ");
        }

        public static List<int[]> findKLargestPairs(int[] nums1, int[] nums2, int k) {
            List<int[]> result = new  List<int[]>();
            Heap<Pairs> minHeap = new Heap<Pairs>(HeapType.Min);

            //Instead of iterating over all the numbers of both arrays, we can iterate only the first ‘K’ numbers 
            //from both arrays. Since the arrays are sorted in descending order, 
            //the pairs with the maximum sum will be constituted by the first ‘K’ numbers from both the arrays.

            for(int i = 0; i < nums1.Length && i < k; i++){
                for(int j = 0; j < nums2.Length && j < k; j++ ){

                    //keep adding K elements
                    if(minHeap.GetSize() < k){
                        minHeap.Add(new Pairs(nums1[i], nums2[j]));
                    }else{

                        // if the sum of the two numbers from array is less than the smallest element from heap
                        // we can 'break'
                        //since the array is sorted in descending order, going further will no give a higher numberr

                        if(nums1[i] + nums2[j] < minHeap.Peek().Sum){
                            break;
                        }else{
                            //replace the smallest element
                            
                            minHeap.Pop();
                            minHeap.Add(new Pairs(nums1[i] , nums2[j]));
                        }
                    }
                }

                

            }

            var pairs = minHeap.Elements;
                foreach(var item in pairs){
                    result.Add(new int[]{ item.value1, item.value2});
                }

                
            return result;
        }
    }
}
