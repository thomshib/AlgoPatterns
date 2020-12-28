using System;
using System.Collections.Generic;

namespace IntervalsIntersection
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
            Interval[] input1 = new Interval[] { new Interval(1, 3), new Interval(5, 6), new Interval(7, 9) };
            Interval[] input2 = new Interval[] { new Interval(2, 3), new Interval(5, 7) };
            Interval[] result = merge(input1, input2);
            Console.WriteLine("Intervals Intersection: ");
            foreach(var interval in result)
            Console.Write("[" + interval.start + "," + interval.end + "] ");
            Console.WriteLine();
        }

         public static Interval[] merge(Interval[] source, Interval[] target) {
             List<Interval> result = new List<Interval>();

             int i = 0;
             int j = 0;

             // 1. a start time lies within b; a & b overlap
             // 2. b start time lies within a; a & b overlap

             while(i < source.Length && j < target.Length){
                 //check for a & b overlap for above two cases

                 if ( (source[i].start >= target[j].start && source[i].start <= target[j].end)
                        ||
                        (target[j].start >= source[i].start && target[j].start <= source[i].end)
                 ){
                     //store the intersection part
                     result.Add(new Interval(
                        Math.Max(source[i].start, target[j].start),
                        Math.Min(source[i].end, target[j].end)
                     ));
                     
                 }

                 //move next from interval finishing first

                 if(source[i].end < target[j].end){
                     i++;
                 }else{
                     j++;
                 }

             }

             return result.ToArray();

         }
    }
}
