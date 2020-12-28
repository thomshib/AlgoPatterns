using System;

namespace RearrangeList
{

     class ListNode{
        public int value;
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
             ListNode head = new ListNode(2);
            head.next = new ListNode(4);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(8);
            head.next.next.next.next = new ListNode(10);
            head.next.next.next.next.next = new ListNode(12);

            reorder(head);

            while(head != null){
                Console.WriteLine(head.value + " ");
                head = head.next;
            }
        }

        public static void reorder(ListNode head) {
            
            var slow = head;
            var fast = head;
            //find the middle
            while(fast != null && fast.next != null){
                slow = slow.next;
                fast = fast.next.next;
            }

            var firstHalfHead = head;
            var secondHalfHead = reverse(slow);

            while(firstHalfHead != null && secondHalfHead != null){
                var firstHalfNext = firstHalfHead.next;
                var secondHalfNext = secondHalfHead.next;

                //swap
                firstHalfHead.next = secondHalfHead;
                secondHalfHead.next = firstHalfNext;

                firstHalfHead = firstHalfNext;
                secondHalfHead = secondHalfNext;
               

            }

            //set the last node to null
            if(firstHalfHead != null){
                firstHalfHead.next = null;
            }

        }

        private static ListNode reverse(ListNode head)
        {
            ListNode prev = null;
            while(head != null){
                var next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }

}
