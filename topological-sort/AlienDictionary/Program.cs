using System;
using System.Collections.Generic;
using System.Text;

namespace AlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findOrder(new String[] { "ba", "bc", "ac", "cab" }));
            Console.WriteLine(findOrder(new String[] { "cab", "aaa", "aab" }));
        }

         public static String findOrder(String[] words) {

             if(words == null || words.Length ==0){
                 return String.Empty;
             }

             Dictionary<char,List<char>> graph = new Dictionary<char, List<char>>();
             Dictionary<char, int> inDegree = new Dictionary<char, int>();

             //initialize the graph

             foreach(var word in words){
                 foreach(var character in word.ToCharArray()){
                     if(!inDegree.ContainsKey(character)){
                         inDegree.Add(character,0);
                     }

                     if(!graph.ContainsKey(character)){
                         graph.Add(character, new List<char>() );
                     }
                 }
             }

             //populate the graph

             for(int i = 0; i < words.Length - 1; i++ ){
                 String w1 = words[i];
                 String w2 = words[i+1];

                 int n = Math.Min(w1.Length , w2.Length);
                 for(int j = 0; j < n; j++){
                     char parent = w1[j];
                     char child = w2[j];

                     if( parent != child ){
                         graph[parent].Add(child);
                         inDegree[child]++;

                         //only the first difference is needed
                         break;
                     }
                 }

             }

             Queue<char> sources = new Queue<char>();

             //find all the sources

             foreach(var vertex in inDegree){
                 if(vertex.Value == 0){
                     sources.Enqueue(vertex.Key);
                 }
             }

             StringBuilder result = new StringBuilder();

             while(sources.Count > 0){
                 var vertex = sources.Dequeue();
                 result.Append(vertex);
                 foreach(var child in graph[vertex]){
                     inDegree[child]--;
                     if(inDegree[child] == 0){
                         sources.Enqueue(child);
                     }
                 }
             }
             
             //there are cycles
             if(result.Length != inDegree.Count){
                 return String.Empty; 
             }
             
          


            
            return result.ToString();
        }
    }
}


