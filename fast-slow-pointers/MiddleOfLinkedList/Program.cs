using System;

namespace MiddleOfLinkedList
{

    class ListNode{
        int value;
        ListNode next;
        public ListNode(int value)
        {
            this.value = value;
        }

        public ListNode Next{
            get{ return next;}
            set{ next = value;}
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
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            Console.WriteLine("Middle Node: " + findMiddle(head).Value);
        }

        public static ListNode findMiddle(ListNode head) {
            var slow = head;
            var fast = head;
            while(fast != null && fast.Next != null){
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }
    }
}
