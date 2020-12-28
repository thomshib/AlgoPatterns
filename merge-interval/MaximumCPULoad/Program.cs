using System;
using System.Collections.Generic;
using DataStructures;

namespace MaximumCPULoad
{
    class Job :IComparable<Job> {
        public int start;
        public int end;
        public int cpuLoad;

        public Job(int start, int end, int cpuLoad) {
            this.start = start;
            this.end = end;
            this.cpuLoad = cpuLoad;
        }

        public int CompareTo(Job other){
            return this.end.CompareTo(other.end);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Job> input = new List<Job>(){
                new Job(1, 4, 3), 
                new Job(2, 5, 4), 
                new Job(7, 9, 6)
            };

            Console.WriteLine("Maximum CPU load at any time: " + findMaxCPULoad(input));
        }

        public static int findMaxCPULoad(List<Job> jobs) {
            
            //sort by start time
            jobs.Sort((a,b) => a.start.CompareTo(b.start));

            Heap<Job> minHeap = new Heap<Job>();


            int currentCPULoad = 0;
            int maxCPULoad = 0;

            foreach(var item in jobs){

                //remove all jobs that ended
                while(minHeap.GetSize() > 0 && item.start > minHeap.Peek().end){
                    currentCPULoad -= minHeap.Pop().cpuLoad;
                }

                //add the current job to the heap
                minHeap.Add(item);
                currentCPULoad += item.cpuLoad;
                maxCPULoad = Math.Max(maxCPULoad, currentCPULoad);
            }

            return maxCPULoad;

            
            
        }
    }
}
