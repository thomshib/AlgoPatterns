using System;
using System.Collections.Generic;

namespace NoRepeatSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(findLengthNoRepeatSubstring("abccde"));
        }


        public static int findLengthNoRepeatSubstring(string input){


            int maxLength = 0;
            int windowStart = 0;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for(int windowEnd = 0; windowEnd < input.Length ; windowEnd++){

                var rightElement = input[windowEnd];

                //shrink the window
                if(charIndexMap.ContainsKey(rightElement)){
                    //the current position of the element is not yet in the map; hence add 1 to the lastknown position
                    //keep windowStart if is ahead of the last position of rightElement 
                    windowStart = Math.Max(windowStart, charIndexMap[rightElement] + 1);
                } 

                //insert the position of the element in the map
                 if(charIndexMap.ContainsKey(rightElement)){
                     charIndexMap[rightElement] = windowEnd;
                 }else{
                    charIndexMap.Add(rightElement, windowEnd);
                 }

                 maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);

            }

            return maxLength;

            


        }
    }
}
