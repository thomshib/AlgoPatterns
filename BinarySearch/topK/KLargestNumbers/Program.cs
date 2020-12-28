using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataStrcutures;

namespace KLargestNumbers
{


    class Entry :IComparable<Entry>{
        public int index;
        public int value;

        public Entry(int index, int value) {
            this.index = index;
            this.value = value;
        }

        public int CompareTo( Entry other)
        {
            return this.value.CompareTo(other.value);
        }
    }

    class KthLargestNumberInStream {
        
        Heap<int> minHeap = new Heap<int>(HeapType.Min);
        int k;
        public KthLargestNumberInStream(int[] nums, int k) {
            this.k = k;
            for(int i = 0; i < nums.Length ;i++){
                add(nums[i]);
            }
        }

        public int add(int num) {
            minHeap.Add(num);
            if(minHeap.GetSize() > this.k){
                minHeap.Pop();
            }

            //return the Kth largest number
            return minHeap.Peek();
            
        }

    }

     class Point : IComparable<Point>{
        public int x;
        public int y;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Point other)
        {
           return this.distFromOrigin().CompareTo(other.distFromOrigin());
        }

        public int distFromOrigin() {
            // ignoring sqrt
            return (x * x) + (y * y);
        }
}
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = findKLargestNumbers(new int[] { 3, 1, 5, 12, 2, 11 }, 3);
            result.ForEach(Console.WriteLine);

            Console.WriteLine("Kth smallest number is ");
            Console.WriteLine(findKthSmallestNumber(new int[]{1, 5, 12, 2, 11, 5 }, 3));

            Point[] points = new Point[] { new Point(1, 3), new Point(3, 4), new Point(2, -1) };

            var output =  findClosestPoints(points, 2);
            foreach(var item in output){
                Console.WriteLine("[" + item.x + " , " + item.y + "] ");
            }

            Console.WriteLine("Minimum cost to connect ropes");
            Console.WriteLine(minimumCostToConnectRopes(new int[]{1, 3, 11, 5}));


            Console.WriteLine("K largest number in a stream");
            int[] input = new int[] { 3, 1, 5, 12, 2, 11 };
            KthLargestNumberInStream kthLargestNumber = new KthLargestNumberInStream(input, 4);
            Console.WriteLine(kthLargestNumber.add(6));
            Console.WriteLine(kthLargestNumber.add(13));
            Console.WriteLine(kthLargestNumber.add(4));

            Console.WriteLine("K closest elements to X");
            result = findClosestElements(new int[] { 5, 6, 7, 8, 9 }, 3, 7);
            result.ForEach(Console.WriteLine);

            Console.WriteLine("Sum of smallest elements between K1 & K2 ");
            Console.WriteLine(findSumOfElements(new int[] { 1, 3, 12, 5, 15, 11 }, 3, 6));
            
        }

         public static List<int> findKLargestNumbers(int[] nums, int k) {
            
            Heap<int> minHeap = new Heap<int>(HeapType.Min);
            for(int i = 0; i < k; i++){
                minHeap.Add(nums[i]);
            }

            for(int i = k ; i < nums.Length; i++){
                if(nums[i] > minHeap.Peek()){
                    minHeap.Pop();
                    minHeap.Add(nums[i]);
                }
            }

            return new List<int>(minHeap.Elements);
        }

        public static int findKthSmallestNumber(int[] nums, int k) {

            Heap<int> maxHeap = new Heap<int>(HeapType.Max);

            for(int i = 0; i < k; i++){
                maxHeap.Add(nums[i]);
            }

            for(int i = k; i < nums.Length; i++){
                if( nums[i] < maxHeap.Peek() ){
                    maxHeap.Pop();
                    maxHeap.Add(nums[i]);
                }
            }

            return maxHeap.Peek();

        }
    
         public static List<Point> findClosestPoints(Point[] points, int k) {

             Heap<Point> maxHeap = new Heap<Point>(HeapType.Max);

             for(int i = 0; i < k ; i++){
                 maxHeap.Add(points[i]);
             }

             for(int i = k ; i < points.Length ; i++){
                 if(points[i].distFromOrigin() < maxHeap.Peek().distFromOrigin()){
                     maxHeap.Pop();
                     maxHeap.Add(points[i]);
                 }
             }

             return new List<Point>(maxHeap.Elements);
         }
    

         public static int minimumCostToConnectRopes(int[] ropeLengths) {

            Heap<int> minHeap = new Heap<int>(HeapType.Min);

            for(int i = 0; i < ropeLengths.Length; i++){
                minHeap.Add(ropeLengths[i]);
            }

            //keep joining the ropes; until we have one left
            int result = 0;
                
    
            while(minHeap.GetSize() > 1){
                int temp = minHeap.Pop() + minHeap.Pop();
                result += temp;
                minHeap.Add(temp);
            }
            return result;




         }
    
        
        public static List<int> findClosestElements(int[] arr, int K, int X) {

            int  index = binarySearch(arr, X);

            int low = index - K;
            int high = index + K;

            low = Math.Max(low,0);
            high = Math.Min(high, arr.Length - 1);

            Heap<Entry> minHeap = new Heap<Entry>(HeapType.Min);

            for(int i = low; i <= high; i++){
                minHeap.Add(new Entry(i, Math.Abs(X - arr[i]) ) );

            }

            List<int> result = new List<int>();

            //pop k elements from heap

            for(int i = 0; i < K; i++){
                result.Add(arr[minHeap.Pop().index]);
            }

            result.Sort();

            return result;


        }

        private static int binarySearch(int[] arr, int target){

            int start = 0;
            int end = arr.Length - 1;

            while(start <= end){

                int mid = start + (end - start) / 2;

                if( arr[mid] == target){
                    return mid;
                }
                if(target > arr[mid]){
                    start = mid + 1;
                }else{
                    end = mid - 1;
                }
            }

            //start = end + 1;

            if( start > 0){
                start = start - 1;
            }
            return start;
        }


         public static int findSumOfElements(int[] nums, int k1, int k2) {

             Heap<int> minHeap = new Heap<int>(HeapType.Min);

             for(int i = 0; i < nums.Length; i++){
                 minHeap.Add(nums[i]);

             }

             //extract K1 elements

             for(int i = 0; i < k1; i++){
                 minHeap.Pop();
             }

             int sum = 0;

            //sum next K2 - K1 - 1 numbers
             for(int i = 0; i < k2 - k1 - 1; i++){
                 sum += minHeap.Pop();
             }

             return sum;




         }
    
    }
}
