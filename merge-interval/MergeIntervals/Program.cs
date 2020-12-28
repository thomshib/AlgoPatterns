using System;
using System.Collections.Generic;

namespace MergeIntervals
{


    class Interval {
        public int start;
        public int end;

        public Interval(int start, int end) {
            this.start = start;
            this.end = end;
        }   
    }
    class Program
    {
        static void Main(string[] args)
        {
             List<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));
            Console.WriteLine("Merged intervals: ");
            foreach (var interval in  merge(input))
                Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();
        }

        public static List<Interval> merge(List<Interval> intervals) {
            
            List<Interval> mergedIntervals = new List<Interval>();


            intervals.Sort((a,b) => a.start.CompareTo(b.start));

            var iter = intervals.GetEnumerator();
            iter.MoveNext();
            var currentInterval  = iter.Current;
            int start = currentInterval.start;
            int end = currentInterval.end;
           

            while(iter.MoveNext()){
                var interval = iter.Current;
                
                //check for overlap; adjust the end
                if(interval.start <= end){
                    end = Math.Max(end, interval.end);
                }else{
                    //non overlapping interval; add the previous interval and reset
                    mergedIntervals.Add(new Interval(start,end));
                    start = interval.start;
                    end = interval.end;
                }

            }

            //add the last interval
            mergedIntervals.Add(new Interval(start,end));
            return mergedIntervals;
        }
    }
}
