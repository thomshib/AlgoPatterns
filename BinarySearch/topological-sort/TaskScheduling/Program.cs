using System;
using System.Collections.Generic;

namespace TaskScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = isSchedulingPossible(3, new int[,] { 
                  { 0, 1 }, 
                  { 1, 2 } 
                  });
            Console.WriteLine("Tasks execution possible: " + result);

             result = isSchedulingPossible(3, new int[,] { 
                  { 0, 1 }, 
                  { 1, 2 },
                  { 2, 0 }
                  });
            Console.WriteLine("Tasks execution possible: " + result);
        }

         public static bool isSchedulingPossible(int tasks, int[,] prerequisites) {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, int> inDegree = new Dictionary<int, int>();

            //initialize graph
            for(int i = 0; i < tasks; i++){
                graph.Add(i, new List<int>());
                inDegree.Add(i,0);
            }

            //populate the graph
            for(int i = 0; i < prerequisites.GetLength(0); i++){
                var parent = prerequisites[i,0];
                var child  = prerequisites[i,1];
                graph[parent].Add(child);
                inDegree[child]++;
            }

            Queue<int> sources = new Queue<int>();

            foreach(var vertex in inDegree){
                if(vertex.Value == 0){
                    sources.Enqueue(vertex.Key);
                }
            }

            int count = 0;

            while(sources.Count >0){
                var currentVertex = sources.Dequeue();
                count++;

                foreach(var child in graph[currentVertex]){
                    inDegree[child]--;
                    if(inDegree[child] ==0){
                        sources.Enqueue(child);
                    }
                }
            }

              
            return count == tasks;
        }
    
        static void allTaskSchedulingOrders(int tasks, int[][] prerequisites){
            
        }
    
    }
}
