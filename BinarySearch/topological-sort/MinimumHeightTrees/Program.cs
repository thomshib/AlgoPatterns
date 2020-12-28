using System;
using System.Collections.Generic;

namespace MinimumHeightTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = findTrees(5,
                new int[,] { 
                     { 0, 1 }, 
                     { 1, 2 }, 
                     { 1, 3 }, 
                     { 2, 4 } }
                    );
            Console.WriteLine("Roots of MHTs: ");
            result.ForEach(Console.WriteLine);
        }

         public static List<int> findTrees(int nodes, int[,] edges) {
            List<int> minHeightTrees = new List<int>();

            if(nodes <= 0){
                return minHeightTrees;
            }
            
            //special case

            if(nodes == 1){
                minHeightTrees.Add(0);
            }

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, int> inDegreeMap = new Dictionary<int, int>();

            //initialize the graph
            for(int i = 0; i < nodes; i++){
                graph.Add(i, new List<int>());
                inDegreeMap.Add(i,0);
            }

            //build the graph
            for(int i = 0; i < edges.GetLength(0); i++){
                var vertex1  = edges[i,0];
                var vertex2 = edges[i,1];

                //since this is a undirected graph; add both vertices
                graph[vertex1].Add(vertex2);
                graph[vertex2].Add(vertex1);

                inDegreeMap[vertex1]++;
                inDegreeMap[vertex2]++;


            }

            //find the leaves; i.e all nodes with 1 degree
            Queue<int> leaves = new Queue<int>();
            foreach(var vertex in inDegreeMap){
                if(vertex.Value == 1){
                    leaves.Enqueue(vertex.Key);
                }
            }

            //remove leaves; until we are left with 1 or 2 nodes

            int totalNodes = nodes;

            while(totalNodes > 2){
                int leavesSize = leaves.Count;
                totalNodes -= leavesSize;
                for(int i = 0; i < leavesSize; i++){
                    var vertex = leaves.Dequeue();
                    var children = graph[vertex];
                    foreach(var child in children){
                        inDegreeMap[child]--;
                        if(inDegreeMap[child] == 1){
                            leaves.Enqueue(child);
                        }
                    }
                }
            }

            
            minHeightTrees.AddRange(leaves.ToArray());


            return minHeightTrees;
        }
    }
}
