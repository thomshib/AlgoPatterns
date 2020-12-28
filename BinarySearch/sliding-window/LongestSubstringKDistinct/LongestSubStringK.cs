

using System;
using System.Collections.Generic;

public class LongestSubstring{

public static int findLongestSubStringK(int K, String input){

    if(input == null || input.Length == 0 || input.Length < K ){
        return -1;
    }

    int maxLength = 0;
    int windowStart = 0;
    Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();

    for(int windowEnd = 0 ; windowEnd < input.Length; windowEnd++){

        char rightChar = input[windowEnd];

        if(charFrequencyMap.ContainsKey(rightChar)){
            charFrequencyMap[rightChar]++;

        }else{
            charFrequencyMap.Add(rightChar,1);

        }

        //shrink the sliding window
        while(charFrequencyMap.Count > K){
            var leftChar = input[windowStart];
            charFrequencyMap[leftChar]--;
            if(charFrequencyMap[leftChar] == 0){
                charFrequencyMap.Remove(leftChar);
            }
            windowStart++;

        }

        maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);



    }

    return maxLength;




    }




public static int MaxFruitCountOf2Types(char[] input){

    if (input.Length <= 0 ){
        return -1;
    }

    Dictionary<char,int> charFrequencyMap  = new Dictionary<char, int>();
    int windowStart = 0;
    int maxLength = 0;

    for(int windowEnd = 0; windowEnd <  input.Length; windowEnd++){
        //add next element
        var leftElement = input[windowEnd];
        if(charFrequencyMap.ContainsKey(leftElement)){
            charFrequencyMap[leftElement]++;
        }else{
            charFrequencyMap[leftElement] = 1;
        }

        //shrink the window
        while(charFrequencyMap.Count > 2){
            var charToRemove = input[windowStart];
            charFrequencyMap[charToRemove]--;
            if(charFrequencyMap[charToRemove] == 0){
                charFrequencyMap.Remove(charToRemove);

            }
            windowStart++;

        }

        maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);


    }

    return maxLength;
    



}


}