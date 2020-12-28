using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataStrcutures;

namespace MergeKSortedLists
{

    class Node : IComparable<Node>{
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

      class MatrixNode : IComparable<MatrixNode>{
        public int row;
        public int col;
        public int value;

        public MatrixNode(int row, int col, int value) {
            this.row = row;
            this.col = col;
            this.value = value;
        }

        public int CompareTo( MatrixNode other)
        {
           return this.value.CompareTo(other.value);
        }
    }

class ListNode: IComparable<ListNode> {
        public int value;
        public ListNode next;

        public ListNode(int value) {
            this.value = value;
        }

        public int CompareTo(ListNode other)
        {
            return this.value.CompareTo(other.value);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(2);
            l1.next = new ListNode(6);
            l1.next.next = new ListNode(8);

            ListNode l2 = new ListNode(3);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(7);

            ListNode l3 = new ListNode(1);
            l3.next = new ListNode(3);
            l3.next.next = new ListNode(4);

            ListNode result = merge(new ListNode[] { l1, l2, l3 });
            Console.WriteLine("Here are the elements form the merged list: ");
            while (result != null) {
                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();


            //--------------------------------------

            int[] l4 = new int[] { 2, 6, 8 };
            int[] l5 = new int[] { 3, 6, 7 };
            int[] l6 = new int[] { 1, 3, 4 };
            List<int[]> lists = new List<int[]>();
            lists.Add(l4);
            lists.Add(l5);
            lists.Add(l6);
            int result1 = findKthSmallest(lists, 5);
            Console.WriteLine("Kth smallest number is: " + result1);
            Console.WriteLine();

            //---------------------------------------

            int[][] matrix = new int[][]{ 
                new int[]{ 2, 6, 8 }, 
                new int[]{ 3, 7, 10 }, 
                new int[] { 5, 8, 11 } 
                };
            int result2 = findKthSmallestMatrix(matrix, 5);
            Console.WriteLine("Kth smallest number is: " + result2);




        }
        
        public static ListNode merge(ListNode[] lists) {
                

                Heap<ListNode> minHeap = new Heap<ListNode>(HeapType.Min);

                //insert the root node of all lists
                foreach(var rootNode in lists){
                    if(rootNode != null){
                        minHeap.Add(rootNode);
                    }
                }

                //take the samllest node from head and add it to list
                //also if the samlles node has a next node add it to the heap

                ListNode resultHead = null;
                ListNode resultTail = null;

                while(minHeap.GetSize() > 0){
                    var node = minHeap.Pop();
                    if(resultHead == null ){
                        resultHead = node;
                        resultTail = node;
                    }else{
                        resultTail.next = node;
                        resultTail = resultTail.next;
                    }

                    if(node.next != null){
                        minHeap.Add(node.next);
                    }
                }
                
                return resultHead;
        }
    
    
          public static int findKthSmallest(List<int[]> lists, int k) {
            
            Heap<Node> minHeap = new Heap<Node>(HeapType.Min);

            //add the first element of all the lists

            for(int i = 0; i < lists.Count ;i++){
                if(lists[i] != null){
                    minHeap.Add(new Node(0,i,lists[i][0]));
                }
            }

            int numberCount = 0;
            int result = 0;

            //take the smallest element from heap
            //if the running coung is k, return the resul
            //if the array of the smallest element has more elements add next element from the array

            while(minHeap.GetSize() > 0){

                var node = minHeap.Pop();
                result = node.value;
                numberCount++;
                if(numberCount == k){
                    break;
                }
                node.elementIndex++;
                if(lists[node.arrayIndex].Length > node.elementIndex){
                    node.value = lists[node.arrayIndex][node.elementIndex];
                    minHeap.Add(node);
                }
            }

            return result;
        }
    
    

         public static int findKthSmallestMatrix(int[][] matrix, int k) {

             Heap<MatrixNode> minHeap = new Heap<MatrixNode>(HeapType.Min);

             //insert the first element of each row in heap
             for(int i = 0; i < matrix.Length; i++){
                 minHeap.Add(new MatrixNode(i,0,matrix[i][0]));
             }

             int numberCount = 0;
             int result = 0;
             while(minHeap.GetSize() > 0){

                 var node = minHeap.Pop();
                 result = node.value;
                 numberCount++;
                 if(numberCount == k){
                     break;
                 }
                 node.col++;

                 if(matrix[node.row].Length > node.col){
                     node.value = matrix[node.row][node.col];
                     minHeap.Add(node);
                 }
             }

             return result;
         }
    }
}
