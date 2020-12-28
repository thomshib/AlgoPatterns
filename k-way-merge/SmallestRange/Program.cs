using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using DataStrcutures;

namespace SmallestRange
{

    class Node:IComparable<Node> {
        public int elementIndex;
        public int arrayIndex;
        public int value;

        public Node(int elementIndex, int arrayIndex, int value) {
            this.elementIndex = elementIndex;
            this.arrayIndex = arrayIndex;
            this.value = value;
        }

        public int CompareTo( Node other)
        {
            return this.value.CompareTo(other.value);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[] l1 = new int[] { 1, 5, 8 };
            int[] l2 = new int[] { 4, 12 };
            int[] l3 = new int[] { 7, 8, 10 };
            List<int[]> lists = new List<int[]>();
            lists.Add(l1);
            lists.Add(l2);
            lists.Add(l3);
            int[] result = findSmallestRange(lists);
            Console.WriteLine("Smallest range is: [" + result[0] + ", " + result[1] + "]");
        }

        public static int[] findSmallestRange(List<int[]> lists) {
           
            Heap<Node> minHeap = new Heap<Node>(HeapType.Min);

            int rangeStart = 0;
            int rangeEnd  = int.MaxValue;
            int currentMaxValue = int.MinValue;

            //insert the firse element of each array

            for(int i = 0; i < lists.Count; i++){
                minHeap.Add(new Node(0,i,lists[i][0]));
                currentMaxValue = Math.Max(currentMaxValue, lists[i][0]);
            }


            //take the samllest element from heap
            //update the ranges, if it gives smaller range
            //if the top element has more elements add next element

            //compare in pairs of three
            while(minHeap.GetSize() == lists.Count){
                var currentNode = minHeap.Pop();
                int currentNodeValue = currentNode.value;

                if(rangeEnd - rangeStart > currentMaxValue - currentNodeValue){
                    rangeStart = currentNodeValue;
                    rangeEnd = currentMaxValue;
                }
                currentNode.elementIndex++;

                if(lists[currentNode.arrayIndex].Length > currentNode.elementIndex){
                    int nextValue = lists[currentNode.arrayIndex][currentNode.elementIndex];
                    currentNode.value = nextValue;
                    minHeap.Add(currentNode);
                    currentMaxValue = Math.Max(currentMaxValue, nextValue);
                }
            }


            return new int[] { rangeStart, rangeEnd };
        }
    }
}
