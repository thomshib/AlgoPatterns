using System;

namespace MaximumPathSum
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
        public static int globalMaximumSum = int.MinValue;
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            Console.WriteLine("Maximum Path Sum: " + findMaximumPathSum(root));
            
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(5);
            root.right.right = new TreeNode(6);
            root.right.left.left = new TreeNode(7);
            root.right.left.right = new TreeNode(8);
            root.right.right.left = new TreeNode(9);
            Console.WriteLine("Maximum Path Sum: " + findMaximumPathSum(root));
        }
        public static int findMaximumPathSum(TreeNode root) {
            globalMaximumSum = int.MinValue;
            calculateSum(root);
            return globalMaximumSum;
        }

        private static int calculateSum(TreeNode currentNode)
        {
            if(currentNode == null){
                return 0;
            }

            int leftTreeSum = calculateSum(currentNode.left);
            int rightTreeSum = calculateSum(currentNode.right);

            //ignore paths with -ve sums
            int maxLeftTreeSum = Math.Max(leftTreeSum ,0);
            int maxRightTreeSum = Math.Max(rightTreeSum ,0);


            int localMaximumSum = maxLeftTreeSum + maxRightTreeSum + currentNode.val;

            globalMaximumSum = Math.Max(globalMaximumSum , localMaximumSum);


            //current Node max Sum is

            return Math.Max(maxLeftTreeSum, maxRightTreeSum) + currentNode.val;

        }
    }
}
