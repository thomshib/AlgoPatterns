using System;
using DataStructures;

namespace MedianOfAStreams
{

    class MedianOfAStream {

        Heap<int>  maxHeap;

        Heap<int> minHeap;

        public MedianOfAStream()
        {
            maxHeap = new Heap<int>(HeapType.Max);
            minHeap = new Heap<int>(HeapType.Min);

        }

        public void insertNum(int num) {
            
            if( maxHeap.IsEmpty() || maxHeap.Peek() >= num){
                maxHeap.Add(num);
            }else{
                minHeap.Add(num);
            }

            // balance the heaps
            // either both the heaps have the same nos of elements 
            // or maxHeap will have one more

            if(maxHeap.GetSize() > minHeap.GetSize() + 1){
                minHeap.Add(maxHeap.Pop());
            }else if(maxHeap.GetSize() < minHeap.GetSize()){
                maxHeap.Add(minHeap.Pop());
            }
            
        }

        public double findMedian() {
           
            if ( maxHeap.GetSize() == minHeap.GetSize() ){
                //return the average
                return (minHeap.Peek() + maxHeap.Peek()) / 2.0; 
            }

            return maxHeap.Peek();
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
           MedianOfAStream medianOfAStream = new MedianOfAStream();
            medianOfAStream.insertNum(3);
            medianOfAStream.insertNum(1);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
             medianOfAStream.insertNum(5);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
            medianOfAStream.insertNum(4);
            Console.WriteLine("The median is: " + medianOfAStream.findMedian());
        }
    }
}
