using System;
using System.Collections.Generic;

namespace LevelOrderTraversal
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

            var result = traverse(root);

            foreach(var items in result){
                Console.Write('[');
                foreach(var item in items){
                    Console.Write(item + ", ");
                }
                Console.Write(']');
                Console.WriteLine();
            }


            
            result = traverseZigZag(root);
            Console.WriteLine("ZigZag Traveral");

            foreach(var items in result){
                Console.Write('[');
                foreach(var item in items){
                    Console.Write(item + ", ");
                }
                Console.Write(']');
                Console.WriteLine();
            }

            var output = findLevelAverages(root);
            Console.WriteLine("Level Averrages");
            foreach(var item in output){
                Console.Write(item + " ");
            }
            Console.WriteLine();



        }

          public static List<List<int>> traverse(TreeNode root) {

              List<List<int>> result = new List<List<int>>();
              if(root ==  null) return result;

              Queue<TreeNode> queue = new Queue<TreeNode>();
              queue.Enqueue(root);

              while(queue.Count > 0){
                  int levelSize = queue.Count;
                  List<int> currentLevelList = new List<int>(levelSize);

                  for(int i = 0; i < levelSize; i++){
                      var currentNode = queue.Dequeue();
                      currentLevelList.Add(currentNode.val);
                      if(currentNode.left != null){
                          queue.Enqueue(currentNode.left);
                      }
                      if(currentNode.right != null){
                          queue.Enqueue(currentNode.right);
                      }
                  }
                  result.Add(currentLevelList);

              }

              return result;

          }



        public static List<List<int>> traverseZigZag(TreeNode root){
            List<List<int>> result = new List<List<int>>();
            if(root ==  null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            int levelSize = 0;
            bool leftToRight = true;

            while(queue.Count > 0 ){
                levelSize = queue.Count;
                var currentLevelList = new List<int>(levelSize);
                for(int i = 0; i < levelSize; i++){
                    var next = queue.Dequeue();
                    if(leftToRight){
                        currentLevelList.Add(next.val);
                    }else{
                        currentLevelList.Insert(0,next.val);
                    }

                    if(next.left != null){
                        queue.Enqueue(next.left);

                    }
                    if(next.right != null){
                        queue.Enqueue(next.right);
                        
                    }
                } 
                result.Add(currentLevelList);
                leftToRight = !leftToRight;
            }

            return result;


        }
    
    
        public static List<double> findLevelAverages(TreeNode root) {

            List<double> result = new List<double>();

            if (root == null){
                return result;
            }

            int levelSize = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0){
                levelSize = queue.Count;
                
                double sum = 0;
                for(int i = 0; i < levelSize; i++){
                    var next = queue.Dequeue();
                    sum += next.val;

                    if(next.left != null){
                        queue.Enqueue(next.left);
                    }

                    if(next.right != null){
                        queue.Enqueue(next.right);
                    }

                }
                result.Add(sum / levelSize);

                
            }

            return result;


        }
    
    
    
    }
}
