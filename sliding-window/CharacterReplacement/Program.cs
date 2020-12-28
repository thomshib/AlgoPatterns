using System;
using System.Collections.Generic;

namespace CharacterReplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findLength("aabccbb",2));
            Console.WriteLine(findOnesLength(new int[]{0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1},3));
        }


        static int findLength(string input, int K){
            int maxLength = 0;
            int windowStart  = 0;
            int maxRepeatLetterCount = 0;
            Dictionary<char, int> letterFrequencyMap = new Dictionary<char, int>();

            for(int windowEnd = 0; windowEnd < input.Length; windowEnd++){
                var rightChar = input[windowEnd];

                if(letterFrequencyMap.ContainsKey(rightChar)){
                    letterFrequencyMap[rightChar]++;
                }else{
                    letterFrequencyMap.Add(rightChar,1);
                }

                maxRepeatLetterCount = Math.Max(maxRepeatLetterCount, letterFrequencyMap[rightChar]);

                //current window size is from windowStart to windowEnd
                // we have a letter that is repeating 'maxRepeatLetterCount' times
                //this means we have a window where we have a letter repeating 'maxRepeatLetterCount' times
                // and the remaining letter we can replace
                //if the remaining letters are more than 'K', shrink the window as we are not allowed to replace more than 
                // 'K' letters

                if( windowEnd - windowStart + 1 - maxRepeatLetterCount > K){
                    var leftChar = input[windowStart];
                    letterFrequencyMap[leftChar]--;
                    windowStart++;
                }

                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);

            }
            
            return maxLength;

        }
    
    
        static int findOnesLength(int[] input, int K){

            int maxLength = 0;
            int windowStart = 0;
            int maxOnesCount = 0;

            for(int windowEnd = 0; windowEnd < input.Length; windowEnd++){
                if(input[windowEnd] == 1) maxOnesCount++;

                //shrink window
                if(windowEnd - windowStart + 1 - maxOnesCount > K){
                    if(input[windowStart] == 1){
                        maxOnesCount--;
                    }
                    windowStart++;
                }

                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }

            return maxLength;
        }
    
    }
}
