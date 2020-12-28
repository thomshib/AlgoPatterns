using System;

namespace basic
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
            ListNode head = new ListNode(2);
            head.next = new ListNode(4);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(8);
            head.next.next.next.next = new ListNode(10);

            var result = reverse(head);
            Console.WriteLine("Reversed List");
            while(result != null){

                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();

            head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            result = reverseSublist(head, 2, 4);

            Console.WriteLine("Reversed List between p & q");
            while(result != null){

                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();


        }

        public static ListNode reverse(ListNode head) {
         
            ListNode prev = null;
            ListNode current = head;
            ListNode next = null;

            while(current != null){

                next = current.next; //temporarily store the next
                current.next = prev; //reverse the current node
                prev = current;      //before we move to the next node, point previous to the current node
                current = next;     //move on the next node

            }

            // after reversal, current will point to null and previous will be the new head
              return prev;
        }

         public static ListNode reverseSublist(ListNode head,int p ,int q) {


            /*
            Skip the first p-1 nodes, to reach the node at position p.
            Remember the node at position p-1 to be used later to connect with the reversed sub-list.
            Next, reverse the nodes from p to q using the same approach discussed in Reverse a LinkedList.
            Connect the p-1 and q+1 nodes to the reversed sub-list.
            */

            if( p == q){
                return head;
            }

            ListNode current = head;
            ListNode prev = null;


            //after skipping p-1 nodes; current will point to p
            for(int i = 0; i < p - 1 && current != null ; ++i){   //++i becaz ranges starts from 1
                prev = current;
                current = current.next;

            }


            // we are interested in three parts of the list
            // part before p;
            // part between p & q
            // part after q


            ListNode lastNodeofFirstPart = prev; // p-1 node
            ListNode lastNodeofSubList = current; // after reversal this will be last node

            ListNode next = null;

            for(int i = 0; i < q-p+1 && current != null ; i++){
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            //connect to the first part; p-1 to prev;
            if(lastNodeofFirstPart != null) {
                lastNodeofFirstPart.next = prev;
            }

            //connect to the last part
            lastNodeofSubList.next = current;
            
            return head;

         }
    }
}
