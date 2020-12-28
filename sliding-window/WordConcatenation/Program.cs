using System;
using System.Collections.Generic;

namespace WordConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = findWordConcatenation("catfoxcat", new String[]{"cat", "fox"});
            result.ForEach(Console.WriteLine);
        }

        static List<int> findWordConcatenation(String input, String[] wordsArray){
            Dictionary<String, int> wordFrequencyMap = new Dictionary<string, int>();

            foreach(var item in wordsArray){
                if (wordFrequencyMap.ContainsKey(item)){
                    wordFrequencyMap[item]++;
                }else{
                    wordFrequencyMap.Add(item,1);
                }
            };

            List<int> resultIndices = new List<int>();
            int wordsCount = wordsArray.Length;
            int wordLength = wordsArray[0].Length;

            for(int i = 0; i <= input.Length - wordsCount * wordLength; i++){
                Dictionary<String,int> wordsSeenMap = new Dictionary<string, int>();
                for(int j = 0; j < wordsCount; j++){
                    var nextWordStartIndex = i + j * wordLength;
                    var nextWord = input.Substring(nextWordStartIndex, wordLength);

                    //break if we don't need this word
                    if(!wordFrequencyMap.ContainsKey(nextWord)){
                        break;
                    }

                    //otherwise, add the word to wordSeen map
                    if(wordsSeenMap.ContainsKey(nextWord)){
                        wordsSeenMap[nextWord]++;
                    }else{
                        wordsSeenMap.Add(nextWord,1);
                    }

                    //break if the word frequency is higher than required
                    if( wordsSeenMap[nextWord] >  wordFrequencyMap[nextWord]){
                        break;
                    }

                    //we reach here if we found the words
                    if( j + 1 == wordsCount){
                        resultIndices.Add(i);
                    }

                }
            }

            return resultIndices;

            
        }
    }
}
