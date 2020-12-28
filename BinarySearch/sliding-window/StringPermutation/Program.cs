using System;
using System.Collections.Generic;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {

            //find Permuttations
            // Console.WriteLine(findPermutation("oidbcaf","abc"));
            // Console.WriteLine(findPermutation("odicf","dc"));
            // Console.WriteLine(findPermutation("bcdxabcdy","bcdyabcdx"));
            // Console.WriteLine(findPermutation("aaacb","abc"));


            //Anagrams
            // var result = findAnagrams("abbcabc","abc");
            // result.ForEach(Console.WriteLine);

            //find minimum window substring

            Console.WriteLine(findMinimumWindowSubstring("aabdec","abc"));
        

        }

        static bool findPermutation(string input, string pattern){
            int windowStart = 0;
            int matched = 0;
            Dictionary<char, int> patternFrequencyMap = new Dictionary<char, int>();

            foreach(var character in pattern  ){
                if(patternFrequencyMap.ContainsKey(character)){
                    patternFrequencyMap[character] ++;
                }else{
                    patternFrequencyMap.Add(character,1);
                }

            }

            for(int windowEnd =0; windowEnd < input.Length ; windowEnd++){


                var rightChar = input[windowEnd];

                //decreement the pattern frequency
                if(patternFrequencyMap.ContainsKey(rightChar)){
                    patternFrequencyMap[rightChar]--;

                    //character is completely matched
                    if(patternFrequencyMap[rightChar] == 0){
                        matched++;
                    }
                }

                if(matched == patternFrequencyMap.Count){
                    return true;

                }

                //shrink the window by one character 
                if(windowEnd >= pattern.Length  - 1){
                    var leftChar = input[windowStart];
                    windowStart++;

                    if(patternFrequencyMap.ContainsKey(leftChar)){
                        //add the char back
                        if(patternFrequencyMap[leftChar] == 0){
                            //reduce the match count before adding back
                            matched--;
                        }
                        patternFrequencyMap[leftChar]++;
                    }
                }


              
            }


            return false;


        }
    
    
         static  List<int> findAnagrams(string input, string pattern){

             int windowStart = 0;
             int matched = 0;
             List<int> resultIndices = new List<int>();
             Dictionary<char,int> patternFrequencyMap = new Dictionary<char, int>();

             foreach(var character in pattern){
                 if (patternFrequencyMap.ContainsKey(character)){
                     patternFrequencyMap[character]++;
                 }else{
                     patternFrequencyMap.Add(character,1);
                 }
             }

             for(int windowEnd = 0; windowEnd < input.Length; windowEnd++){
                var rightChar = input[windowEnd];
                  if (patternFrequencyMap.ContainsKey(rightChar))
                   {
                     patternFrequencyMap[rightChar]--;
                     if(patternFrequencyMap[rightChar] == 0){
                         matched++;
                     }
                 
                   }
                
                //found an anagram
                if(patternFrequencyMap.Count  == matched){
                    resultIndices.Add(windowStart);
                }

                //shrink the window
                if(windowEnd >= pattern.Length - 1){
                    var leftChar = input[windowStart];
                    windowStart++;
                    if (patternFrequencyMap.ContainsKey(leftChar)){
                        if(patternFrequencyMap[leftChar] == 0){
                            matched--;
                        }
                        patternFrequencyMap[leftChar]++;

                    }
                }

         }
          return resultIndices;
    
    }


        static string findMinimumWindowSubstring(string input, string pattern){

            int windowStart = 0;
            int subStringStart = 0;
            int minLength = input.Length + 1;
            int matched = 0;

            Dictionary<char,int> patternFrequencyMap = new Dictionary<char, int>();

            foreach (var item in pattern)
            {
                if(patternFrequencyMap.ContainsKey(item)){
                    patternFrequencyMap[item]++;
                }else{
                    patternFrequencyMap.Add(item, 1);
                }
                
            }


            for(int windowEnd = 0; windowEnd < input.Length; windowEnd++){


                var rightChar = input[windowEnd];


                if(patternFrequencyMap.ContainsKey(rightChar)){
                    patternFrequencyMap[rightChar]--;
                    //count every match
                    if(patternFrequencyMap[rightChar] >= 0){
                        matched++;
                    }

                }

                //shrink the window
                while(matched == pattern.Length){

                    //find the start and length of the substring
                    if(minLength > windowEnd - windowStart + 1){
                        minLength = windowEnd - windowStart + 1;
                        subStringStart = windowStart;
                    }

                    char leftChar = input[windowStart];
                    windowStart++;

                    if(patternFrequencyMap.ContainsKey(leftChar)){
                        if(patternFrequencyMap[leftChar] == 0){
                            matched--;
                        }
                        patternFrequencyMap[leftChar]++;
                    }


                }



            }

            return minLength > input.Length ? "" : input.Substring(subStringStart, minLength);




        }


}
}
