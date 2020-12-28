using System;
using System.Collections.Generic;
using DataStructures;

namespace TaskScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] tasks = new char[] { 'a', 'a', 'a', 'b', 'c', 'c' };
            Console.WriteLine("Minimum intervals needed to execute all tasks: " + scheduleTasks(tasks, 2));

        }

        public static int scheduleTasks(char[] tasks, int n) {

            Heap<int> maxHeap = new Heap<int>(HeapType.Max);

            Dictionary<char,int> charFrequencyMap = new Dictionary<char, int>();

            foreach(var character in tasks){
                if(charFrequencyMap.ContainsKey(character)){
                    charFrequencyMap[character]++;
                }else{
                    charFrequencyMap.Add(character, 1);
                }
            }

            //add all the frequncies to the max heap
            foreach(var frequency in charFrequencyMap.Values){
                maxHeap.Add(frequency);
            }

            int maxFrequency = maxHeap.Pop();
            // [a, a, a, b] 
            // a -> idle -> idle -> a -> idle -> idle -> a; 4 idle times for maxfreq 3
            int totalIdleTime = (maxFrequency - 1) * n;

            while(maxHeap.GetSize() > 0){

                int currentFrequency = maxHeap.Pop();

                //it is equal to maxfrequency; add 1 to account for last task
                // A B idle A B idle A B(this B needs to be considered)
                if( currentFrequency == maxFrequency){
                    totalIdleTime -= currentFrequency;
                    totalIdleTime += 1;
                }else{
                    //keep substracting idle time
                    totalIdleTime -= currentFrequency;
                }
            }

            if( totalIdleTime > 0){
                return totalIdleTime + tasks.Length;
            }else{
                return tasks.Length;
            }

        }
    }
}
