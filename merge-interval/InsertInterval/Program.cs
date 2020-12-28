using System;
using System.Collections.Generic;

namespace InsertInterval
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
            input.Add(new Interval(1, 3));
            input.Add(new Interval(5, 7));
            input.Add(new Interval(8, 12));
            Console.WriteLine("Intervals after inserting the new interval: ");
            foreach (var interval in insert(input, new Interval(4, 6)))
                Console.Write("[" + interval.start + "," + interval.end + "] ");
             Console.WriteLine();
        }

        public static List<Interval> insert(List<Interval> intervals, Interval newInterval) {
              List<Interval> mergedIntervals = new List<Interval>();

              if(intervals == null || intervals.Count == 0){
                   mergedIntervals.Add(new Interval(newInterval.start, newInterval.end));
                   return mergedIntervals;
              }

              int index = 0;

              //skip and add all intervals that come before newInterval

              while(index < intervals.Count && intervals[index].end < newInterval.start){
                  mergedIntervals.Add(intervals[index]);
                  index++;

              }

              //merge all intervals that overlap with newInterval 
              while(index < intervals.Count && intervals[index].start <= newInterval.end){
                  newInterval.start = Math.Min(intervals[index].start, newInterval.start);
                  newInterval.end = Math.Max(intervals[index].end, newInterval.end);
                  index++;
              } 

              //insert the new interval
              mergedIntervals.Add(newInterval);

              //add the remaining
               while(index < intervals.Count){
                    mergedIntervals.Add(intervals[index]);
                   index++;
               }




            return mergedIntervals;
        }
    }
}
