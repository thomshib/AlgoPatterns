using System;

namespace RotateList
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

            ListNode result = rotate(head, 3);

            while(result != null){
                Console.Write(result.value + " ");
                result = result.next;
            }
            Console.WriteLine();
        }

        private static ListNode rotate(ListNode head, int rotations)
        {
            if(head == null || head.next == null || rotations <=0){
                return head;
            }

            // head -> 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> null; rotations = 3
            // head -> 4 -> 5 - > 6 -> 1 -> 2 -> 3 > null 

            int listLength = 1;
            ListNode lastNode = head;
            while(lastNode.next != null)
            {
                lastNode = lastNode.next;
                listLength++;
            };

            lastNode.next = head; // create a circular list; to make it warp around
            rotations %= listLength;  // no need to rotate more than list length; 3
            int skipLength = listLength - rotations;
            ListNode lastNodeOfRotatedList = head;

            for(int i = 0; i < skipLength - 1; i++){
                lastNodeOfRotatedList = lastNodeOfRotatedList.next; //lastnode now points to node 3
            }

            //change head
            head = lastNodeOfRotatedList.next;
            lastNodeOfRotatedList.next = null;

            return head;






        }
    }
}
