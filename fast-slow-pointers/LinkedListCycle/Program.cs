using System;

namespace LinkedListCycle
{

    class ListNode{
        int value;
        public ListNode next;
        public ListNode(int value)
        {
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

            Console.WriteLine("LinkedList has cycle: " + hasCycle(head));

            head.next.next.next.next.next.next = head.next.next;

            Console.WriteLine("LinkedList has cycle: " + hasCycle(head));



        }

         public static bool hasCycle(ListNode head) {

             ListNode fast = head;
             ListNode slow = head;

             //fast moves two steps
             while(fast != null && fast.next != null){
                 fast = fast.next.next;
                 slow = slow.next;

                 if(slow == fast){
                     return true;
                 }
             }
             return false;

         }
    }
}
