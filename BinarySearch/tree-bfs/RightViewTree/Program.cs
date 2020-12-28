using System;
using System.Collections.Generic;

namespace RightViewTree
{
    class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x) {
        val = x;
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
            root.left.left.left = new TreeNode(3);
            List<TreeNode> result =traverse(root);
            foreach (TreeNode node in result) {
                Console.Write(node.val + " ");
            }
            Console.WriteLine();
        }

         public static List<TreeNode> traverse(TreeNode root) {
            List<TreeNode> result = new List<TreeNode>();

            if(root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
           
            TreeNode currentNode = null;
            int levelSize = 0;
            

            while(queue.Count > 0){

                levelSize = queue.Count;
                for(int i = 0; i < levelSize; i++){
                     currentNode = queue.Dequeue();

                     if( i == levelSize - 1){
                         result.Add(currentNode);
                     }

                     if(currentNode.left != null){
                         queue.Enqueue(currentNode.left);

                     }

                     if(currentNode.right != null){
                         queue.Enqueue(currentNode.right);

                     }

                     

                }

            }

            
            
            return result;
        }
    }
}
