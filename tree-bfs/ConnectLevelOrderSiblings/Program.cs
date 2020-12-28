using System;
using System.Collections.Generic;

namespace ConnectLevelOrderSiblings
{

class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;

        public TreeNode(int x) {
            val = x;
            left = right = next = null;
        }

        public void printLevelOrderTraversal(){
            TreeNode nextRootNode = this;

            while(nextRootNode != null){
                TreeNode currentNode = nextRootNode;
                nextRootNode = null;
                while(currentNode != null){
                    Console.Write( currentNode.val + " ");
                    if(nextRootNode == null){
                        if(currentNode.left != null){
                            nextRootNode = currentNode.left;
                        }else if(currentNode.right != null){
                            nextRootNode = currentNode.right;
                        }
                    }
                    currentNode = currentNode.next;
                }
                Console.WriteLine();
            }


        }
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
            root.printLevelOrderTraversal();
        }

        public static void connect(TreeNode root) {
           
           if(root == null) return;

           Queue<TreeNode> queue = new Queue<TreeNode>();
           int levelSize = 0;
           queue.Enqueue(root);
           while(queue.Count > 0){
               levelSize = queue.Count;
               TreeNode previousNode = null;
               TreeNode currentNode = null;
               for(int i = 0; i < levelSize; i++){
                    currentNode = queue.Dequeue();

                   if(currentNode.left !=null){
                       queue.Enqueue(currentNode.left);
                   }
                   if(currentNode.right !=null){
                       queue.Enqueue(currentNode.right);
                   }

                   if(previousNode != null){
                       previousNode.next = currentNode;
                   }
                   previousNode = currentNode;
               }
               currentNode.next = null;
               

           }
           

        }
    }
}
