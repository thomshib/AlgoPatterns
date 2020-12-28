using System;

namespace TreeDiameter
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
        public static int treeDiameter = 0;
        static void Main(string[] args)
        {
           TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(6);
            Console.WriteLine("Tree Diameter: " + findDiameter(root));
        }

         public static int findDiameter(TreeNode root) {
          
             calculateHeight(root);
             return treeDiameter;
        }

        private static int calculateHeight(TreeNode currentNode)
        {
            if(currentNode == null){
                return 0;
            }

            int leftTreeHeight = calculateHeight(currentNode.left);
            int rightTreeHeight = calculateHeight(currentNode.right);

            //diamter is the sum of left tree and right tree plus one for the currrent node
            int diameter = leftTreeHeight + rightTreeHeight + 1;

            //update the max diameter found so far

            treeDiameter = Math.Max(treeDiameter, diameter);

            //for the currrentnode, height is the max of leftSubtree & rightSubTree plus one
            return Math.Max(leftTreeHeight,rightTreeHeight) + 1;

        }
    }
}
