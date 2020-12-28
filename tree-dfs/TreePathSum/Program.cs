using System;
using System.Collections.Generic;

namespace TreePathSum
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
            Console.WriteLine("Tree has path: " + hasPath(root, 23));
            Console.WriteLine("Tree has path: " + hasPath(root, 16));

            var result = findPaths(root, 23);
            Console.WriteLine();
            foreach(var items in result){
                Console.Write("[");
                foreach(var item in items){
                    Console.Write(item + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }

            root = new TreeNode(12);
            root.left = new TreeNode(7);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(4);
            root.right.left = new TreeNode(10);
            root.right.right = new TreeNode(5);
            Console.WriteLine("Tree has path: " + countAllPathsSum(root, 11));


        }

         public static bool hasPath(TreeNode root, int sum) {

             if(root == null)
                return false;

            //if a leaf node and the sum is equall to the node sum

            if(root.left == null && root.right == null && sum == root.val){
                return true;
            }
            
            //recurisvely travese the left and right tree
            
            return hasPath(root.left, sum - root.val) || hasPath(root.right, sum - root.val) ;
        }


        public static List<List<int>> findPaths(TreeNode root, int sum) {
            List<List<int>> allPaths = new  List<List<int>>();
            List<int> currentPath = new List<int>();
            findPathRecursive(root, sum, currentPath,allPaths);

           
            return allPaths;
        }

        private static void findPathRecursive(TreeNode currentNode, int sum, List<int> currentPath, List<List<int>> allPaths)
        {
            //base case
            if(currentNode == null){
                return;
            }

            //add the currentNode to the path
            currentPath.Add(currentNode.val);

            //check leaf node
            if(currentNode.left == null && currentNode.right == null && sum == currentNode.val ){
                allPaths.Add(new List<int>(currentPath));
            }else{
                //recurse left sub tree
                findPathRecursive(currentNode.left, sum - currentNode.val, currentPath, allPaths);

                //recurse right sub tree
                findPathRecursive(currentNode.right, sum - currentNode.val, currentPath, allPaths);

            }

            //remove the current node and backtrack
            currentPath.RemoveAt(currentPath.Count - 1);



        }

         public static int countAllPathsSum(TreeNode root, int sum) {

             List<int> currentPath = new List<int>();
             return countPathRecursive(root, sum, currentPath);
            
        }

        private static int countPathRecursive(TreeNode currentNode, int sum, List<int> currentPath)
        {
            if(currentNode == null){
                return 0;
            }

            //add the node to the path
            currentPath.Add(currentNode.val);

            int pathCount = 0; 
            int pathSum = 0;

            //find the sum of all sub-path in the current list
                for(int i = currentPath.Count - 1; i >=0 ; i--){
                pathSum += currentPath[i];
                
                //pathSum matches sum; we found a path
                if(pathSum == sum){
                    pathCount++;
                } 
            }

            //traverse the left sub tree
            pathCount += countPathRecursive(currentNode.left, sum, currentPath);

            //traverse the right sub tree

            pathCount += countPathRecursive(currentNode.right, sum, currentPath);


            //remove the currentNode and backtrack
            currentPath.RemoveAt(currentPath.Count - 1);    
            

            return pathCount;


        }
    }
}
