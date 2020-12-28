using System;

namespace PalindromicLinkedList
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
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(2);
            Console.WriteLine("Is palindrome: " + isPalindrome(head));
        }

        public static bool isPalindrome(ListNode head) {
            
            //find the middle of the list
            var slow = head;
            var fast = head;
            while(fast != null && fast.next != null){
                slow = slow.next;
                fast = fast.next.next;
            }

            //slow is the middle
            //reverse the second half

            var headSecondHalf = reverse(slow);
            var copyHeadSecondHalf = headSecondHalf;

            while(head != null && headSecondHalf != null){
                if(head.value != headSecondHalf.value) break;
                headSecondHalf = headSecondHalf.next;
                head = head.next;
            }

            //reverse it back
            reverse(copyHeadSecondHalf);
            if(head == null && headSecondHalf == null){//both reached end
                return true;
            }


            return false;
        }

        private static ListNode reverse(ListNode head){
            ListNode prev = null;
            while(head != null){
                var next = head.next;
                head.next =  prev;
                prev = head;
                head = next;
            }
            return prev;
        }


    }
}
