using System;
using System.Collections.Generic;

namespace SequenceReconstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = canConstruct(new int[] { 1, 2, 3, 4 },
                    new int[,] { 
                         { 1, 2 }, 
                         { 2, 3 }, 
                         { 3, 4 } 
                        });

            Console.WriteLine(result);

            result = canConstruct(new int[] { 1, 2, 3, 4 },
                    new int[,] { 
                         { 1, 2 }, 
                         { 2, 3 }, 
                         { 2, 4 } 
                        });

            Console.WriteLine(result);
        }

        public static bool canConstruct(int[] originalSeq, int[,] sequences) {

            List<int> result = new List<int>();

            if(originalSeq.Length == 0) return false;

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, int> inDegreeMap = new Dictionary<int, int>();

            //initialize the graph

            for(int i = 0; i < sequences.GetLength(0); i++){
                for(int j = 0; j < sequences.GetLength(1); j++){
                    if(!inDegreeMap.ContainsKey(sequences[i,j])){
                        inDegreeMap.Add(sequences[i,j], 0);
                    }
                    if(!graph.ContainsKey(sequences[i,j])){
                        graph.Add(sequences[i,j], new List<int>());
                    }
                        
                }
            }


            //populate graph
             for(int i = 0; i < sequences.GetLength(0); i++){
                for(int j = 1; j < sequences.GetLength(1); j++){
                    var parent = sequences[i, j-1];
                    var child = sequences[i,j];
                    graph[parent].Add(child);
                    inDegreeMap[child]++;
                }
             }

             // if we do not have ordering rules for all elements

             if(inDegreeMap.Count != originalSeq.Length){
                 return false;
             }

             //find all source
             Queue<int> sources = new Queue<int>();

             foreach(var vertex in inDegreeMap){
                 if(vertex.Value == 0){
                     sources.Enqueue(vertex.Key);
                 }
             }


             while(sources.Count > 0){
                 if(sources.Count > 1){
                     return false; // there are more than one way to reconstruct the sequence
                 }

                 if( originalSeq[result.Count] != sources.Peek()){
                     return false; //the source number is different from the original sequence
                 }

                 var vertex = sources.Dequeue();
                 result.Add(vertex);
                 foreach(var child in graph[vertex]){
                     inDegreeMap[child]--;
                     if(inDegreeMap[child] == 0){
                         sources.Enqueue(child);
                     }
                 }


             }

             return result.Count == originalSeq.Length;

        }
    }
}
