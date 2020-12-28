using System;
using System.Collections.Generic;

namespace UniqueTrees
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
            var result = findUniqueTrees(2);
            Console.WriteLine(result.Count);
        }

        public static List<TreeNode> findUniqueTrees(int n) {
            if( n <= 0 ){
                return null;
            }

            return findRecursiveTrees(1, n);

        }

        private static List<TreeNode> findRecursiveTrees(int start, int end)
        {
            List<TreeNode> result = new List<TreeNode>();

            //base condition; return null for empty subtree
            //consider n = 1; for this case start = end = 1; we should have one tree
            // we make two recursive calls findRecursiveTrees(1, 0) & findRecursiveTrees(2,1)

            if(start > end){
                result.Add(null);
                return result;
            }

            for(int i = start ; i <= end; i++){
                var leftSubTrees = findRecursiveTrees(start, i-1);
                var rightSubTrees = findRecursiveTrees(i+1, end);

                foreach(var leftTree in leftSubTrees){
                    foreach(var rightTree in rightSubTrees){
                        TreeNode root = new TreeNode(i);
                        root.left = leftTree;
                        root.right = rightTree;
                        result.Add(root);
                    }
                    
                }

                
            }

            return result;
            
        }
    }
}
