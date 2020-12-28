using System;

namespace LinkedListCycleStart
{
    //https://www.educative.io/courses/grokking-the-coding-interview/N7pvEn86YrN

    class ListNode{
        int value;
        public ListNode next;
        public ListNode(int value)
        {
            this.value = value;
        }

        public int Value{
            get{return value;}
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

            head.next.next.next.next.next.next = head.next.next;
            Console.WriteLine("LinkedList cycle start: " + findCycleStart(head).Value);
        }

        public static ListNode findCycleStart(ListNode head) {

            int cycleLength = 0;

            //find linkedList cycle
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null){
                fast = fast.next.next;
                slow = slow.next;
                if(slow == fast){
                    cycleLength = calculateCycleLength(slow);
                    break;
                }
            }

            return findStart(head, cycleLength);



        }

        private static ListNode findStart(ListNode head, int cycleLength)
        {
            var pointer1 = head;
            var pointer2 = head;


            //move pointer2 ahead cyclelength nodes
            while(cycleLength >0){
                pointer2 = pointer2.next;
                cycleLength--;
            }

            //increment both pointers untill they meet
            while(pointer1 != pointer2){
                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }
            return pointer1;
        }

        private static int calculateCycleLength(ListNode slow)
        {
            int cycleLength = 0;
            var currentNode = slow;

            do{
                currentNode = currentNode.next;
                cycleLength++;

            }while(currentNode != slow);
            
            return cycleLength;
        }
    }
}
