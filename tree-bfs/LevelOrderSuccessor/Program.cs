using System;
using System.Collections.Generic;

namespace LevelOrderSuccessor
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
                root.left.left = new TreeNode(9);
                root.right.left = new TreeNode(10);
                root.right.right = new TreeNode(5);
                TreeNode result =findSuccessor(root, 12);
                if(result != null){
                    Console.WriteLine(result.val + " ");
                }

                result = findSuccessor(root,9);
                 if(result != null){
                    Console.WriteLine(result.val + " ");
                }
        }

         public static TreeNode findSuccessor(TreeNode root, int key) {
               
                if(root == null){
                return null;    
                }

                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                while(queue.Count > 0){

                    var next = queue.Dequeue();
                    if(next.left != null){
                        queue.Enqueue(next.left);

                    }
                    if(next.right != null){
                        queue.Enqueue(next.right);
                        
                    }

                    //break if we have found the key

                    if(next.val == key){
                        break;
                    }
                }

                return queue.Dequeue();
                
            }


    }
}
