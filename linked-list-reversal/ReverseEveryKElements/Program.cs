using System;

namespace ReverseEveryKElements
{

    class ListNode {
        public int value = 0;
        public ListNode next;

        public ListNode(int value) {
            this.value = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);
            head.next.next.next.next.next.next.next = new ListNode(8);

            ListNode result = reverse(head, 3);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null) {
                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();



            head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);
            head.next.next.next.next.next.next.next = new ListNode(8);

            result = reverseAlternateK(head, 2);
            Console.WriteLine("Nodes of the Alternate K Reversed LinkedList are: ");
            while (result != null) {
                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();
        }

         public static ListNode reverse(ListNode head, int k) {

             if(head == null || k <= 1){
                 return head;
             }

             // a -> b -> c -> d -> e; reverse b & c
             // a -> c -> b -> d -> e; after reversal
             // we need to remember a ; a = lastNodeofFirstPart
             // and remember b; lastNodeofSubList

             // after reversal ; 
             // 1. current = d; so lasNodeofSubList.next = current; this links b -> d
             // 2. previous = c; so lastNodeofFirstpart.next  = previous; this links a -> c

             

            ListNode current = head;
            ListNode prev = null;
            ListNode lastNodeOfFirstPart;
            ListNode lastNodeOfSubList;

             while(true){
                //current is one node ahead of prev
                //at the end of list; current will point to null and prev will point to the lastnode
                  lastNodeOfFirstPart = prev;
                  lastNodeOfSubList  = current;     
                  ListNode next = null;

                  for(int i = 0; i < k && current != null; i++){
                      next = current.next;
                      current.next = prev;
                      prev = current;
                      current = next;
                  }

                  //connect with previous part
                  if(lastNodeOfFirstPart != null){
                      lastNodeOfFirstPart.next = prev;
                  }else{
                      //changing the first node of the list
                      head = prev;
                  }

                  //connect with remaining part of the lisg
                  lastNodeOfSubList.next = current;

                  if (current == null){
                      break;
                  }
                  //prepare for the next sublist
                  prev = lastNodeOfSubList;
             }

             return head;



         }
    
    
         public static ListNode reverseAlternateK(ListNode head, int k) {


             ListNode current = head;
             ListNode prev = null;
             ListNode lastNodeofFirstPart = null;
             ListNode lastNodeofSubList = null;

             while(true){

                 lastNodeofFirstPart = prev;
                 lastNodeofSubList = current;
            
                ListNode next = null;

                 for(int i = 0; i < k && current != null; i++){
                    next = current.next;
                    current.next = prev;
                    prev = current;
                    current = next; 
                 }

                 //connect to the first part
                 if(lastNodeofFirstPart != null){
                     lastNodeofFirstPart.next = prev;

                 }else{
                     head = prev;
                 }

                 //connect the last part
                 lastNodeofSubList.next = current;

                 //skip k nodes

                 for(int i = 0; i < k && current != null; i++){
                     prev = current;
                     current = current.next;
                 }

                 if(current == null){
                     break;
                 }
                


             }

             return head;


         }

    
    }
}
