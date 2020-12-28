using System;
using System.Collections.Generic;

namespace sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result =sort(4,
                new int[,] { 
                             { 3, 2 }, 
                             { 3, 0 }, 
                             { 2, 0 },
                             { 2, 1 } 
                             }
                            );
            result.ForEach(Console.WriteLine);

        }

          public static List<int> sort(int vertices, int[,] edges) {

              //graph

              Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
              Dictionary<int, int> inDegree = new Dictionary<int, int>();
              List<int> result = new List<int>();

              //initialize the graph

              for(int i = 0; i <vertices; i++){
                  graph.Add(i, new List<int>());
                  inDegree.Add(i,0);
              }

              //populate the graph
              for(int i = 0; i < edges.GetLength(0); i++){
                  var parent = edges[i,0];
                  var child =  edges[i,1];
                  graph[parent].Add(child);

                  if(!inDegree.ContainsKey(child)){
                      inDegree.Add(child, 1);
                  }else{
                      inDegree[child]++;
                  }
              }

              Queue<int> sources = new Queue<int>();

              //find the sources in the graph
              foreach(var item in inDegree){
                  if(item.Value == 0){
                      sources.Enqueue(item.Key);
                  }
              }

              while(sources.Count > 0){
                  var currentVertex = sources.Dequeue();
                  result.Add(currentVertex);

                  foreach(var child in graph[currentVertex]){
                      inDegree[child]--;
                      if(inDegree[child] == 0){
                          sources.Enqueue(child);
                      }
                  }
              }

              //check for cycles

              if(result.Count != vertices){
                  return new List<int>();
              }

             return result;
          }
    }
}
