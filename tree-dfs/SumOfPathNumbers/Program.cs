using System;

namespace SumOfPathNumbers
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
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(0);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Total Sum of Path Numbers: " + findSumOfPathNumbers(root));

             Console.WriteLine("Does Tree has sequence  1->1->6 : " + findPath(root, new int[]{1,1,6}));


        }


         public static int findSumOfPathNumbers(TreeNode root) {
            
            return pathRootToLeafPathNumbers(root, 0);
        }

        private static int pathRootToLeafPathNumbers(TreeNode currentNode, int pathSum)
        {
            //base condition
            if(currentNode == null){
                return 0;
            }

            pathSum = pathSum * 10  + currentNode.val;

            if(currentNode.left == null && currentNode .right == null){
                return pathSum;
            }

            return pathRootToLeafPathNumbers(currentNode.left, pathSum) +
                pathRootToLeafPathNumbers(currentNode.right, pathSum);  



        }

        public static bool findPath(TreeNode root, int[] sequence) {
            
            return hasPath(root, sequence,0);
        }

        private static bool hasPath(TreeNode currentNode, int[] sequence, int index)
        {
            if(currentNode == null){
                return false;
            }

            if(index >= sequence.Length ||  currentNode.val != sequence[index]){
                return false;
            }


            if(currentNode.left == null && currentNode.right == null && index == sequence.Length - 1){
                return true;
            }

            return hasPath(currentNode.left,sequence, index + 1) || 
                hasPath(currentNode.right,sequence,index + 1);

        }
    }
}
