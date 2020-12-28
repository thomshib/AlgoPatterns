using System;
using System.Collections.Generic;

namespace ConnectAllSiblings
{
    class TreeNode{
        public int val ;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;

        public TreeNode(int val){
            this.val = val;
            this.left = this.right = this.next = null;

        }

        public void printTree(){
            TreeNode current = this;
            Console.WriteLine("Travesal using next pointer");
            while(current != null){
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

    
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(9);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            connect(root);
            root.printTree();
        }

        public static void connect(TreeNode root) {
            if (root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int levelSize = 0;
            TreeNode previous = null;
            TreeNode current = null;
            
            while(queue.Count > 0){
                    current = queue.Dequeue();

                    
                    if(current.left != null){
                        queue.Enqueue(current.left);
                    }

                    if(current.right != null){
                        queue.Enqueue(current.right);
                    }

                    if(previous != null){
                        previous.next = current;
                    }
                    previous = current;

                }
                

        }
    }
}
}

