using System;
using DataStructures;

namespace SlidingWindowMedian
{

    class SlidingWindowMedian {
        Heap<int> minHeap;
        Heap<int> maxHeap;

        public SlidingWindowMedian()
        {
            maxHeap = new Heap<int>(HeapType.Max);
            minHeap = new Heap<int>(HeapType.Min);
        }

        public double[] findSlidingWindowMedian(int[] nums, int k) {

            double[] result = new double[nums.Length - k + 1];

            for(int i = 0; i < nums.Length; i++){

                if(maxHeap.GetSize() == 0 || maxHeap.Peek() >= nums[i]){
                    maxHeap.Add(nums[i]);
                }else{
                    minHeap.Add(nums[i]);
                }

                RebalanceHeaps();

                //if we have k elements in the sliding window
                if( i - k + 1 >= 0  ){
                    //find the median
                    if(maxHeap.GetSize() == minHeap.GetSize()){
                        result[i-k+1] = (maxHeap.Peek() + minHeap.Peek() ) / 2.0;
                    }else{
                        result[i-k+1] = maxHeap.Peek();
                    }

                    //remove the element going out
                    var elementToBeRemoved = nums[i-k+1];

                    if(elementToBeRemoved <= maxHeap.Peek()){
                        maxHeap.
                    }


                }
            } 

        }

        private void RebalanceHeaps()
        {
            //maxHeap should have one more than minHeap

            if(maxHeap.GetSize() > minHeap.GetSize() + 1){
                minHeap.Add(maxHeap.Pop());
            }else if( maxHeap.GetSize() < minHeap.GetSize()){
                maxHeap.Add(minHeap.Pop());
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
