using System;
using System.Collections.Generic;

namespace MinimumBinaryTreeDepth
{

    class TreeNode{
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val){
            this.val = val;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine(findDepth(root));
        }

        public static int findDepth(TreeNode root) {

            if (root == null){
                return -1;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            int minimumDepth = 0;
            int levelSize = 0;

            queue.Enqueue(root);
            while(queue.Count > 0){
                minimumDepth++;
                levelSize = queue.Count;
                for(int i = 0; i < levelSize; i++)
                {
                   var next = queue.Dequeue();

                   //check if this is a leaf node
                   if(next.left == null && next.right == null){
                       return minimumDepth;
                   } 

                   if(next.left != null){
                       queue.Enqueue(next.left);
                   }
                    if(next.right != null){
                       queue.Enqueue(next.right);
                   }

                }
            }

            return minimumDepth;
            
           
            
        }



    }
}
