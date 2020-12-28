using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DataStructures;

namespace EmployeeFreeTime
{
 class Interval {
    public int start;
    public int end;

    public Interval(int start, int end) {
        this.start = start;
        this.end = end;
    }
}

    class EmployeeInterval : IComparable<EmployeeInterval>{ 
        public Interval interval;
        public int employeeIndex; //index of the List
        public int intervalIndex; //index of the interval in the List

        public EmployeeInterval(Interval interval, int employeeIndex, int intervalIndex)
        {
            this.interval = interval;
            this.employeeIndex = employeeIndex;
            this.intervalIndex = intervalIndex;
        }

        
        public int CompareTo(EmployeeInterval other)
        {
            return this.interval.start.CompareTo(other.interval.start);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<List<Interval>> input = new List<List<Interval>>(){
            
                new List<Interval>(){
                    new Interval(1,3), new Interval(5,6)
                },
                new List<Interval>(){
                    new Interval(2,3), new Interval(6,8)
                }

            };

            List<Interval> result = findEmployeeFreeTime(input);
            Console.WriteLine("Free intervals: ");
            foreach (var  interval in  result)
                Console.Write("[" + interval.start + ", " + interval.end + "] ");
            Console.WriteLine();
        }

        public static List<Interval> findEmployeeFreeTime(List<List<Interval>> schedule) {
            List<Interval> result = new List<Interval>();
           
           Heap<EmployeeInterval> minHeap = new Heap<EmployeeInterval>();


           //insert the first interval of each employee in the heap
           for(int i = 0; i < schedule.Count; i++){
               minHeap.Add(new EmployeeInterval(schedule[i][0],i,0));
           }

           var previousInterval = minHeap.Peek().interval;
           while(minHeap.GetSize() > 0){
               var queueTop = minHeap.Pop();
               //if previousInterval does not overlap with next; add it to result
               if(previousInterval.end < queueTop.interval.start){
                   result.Add(new Interval(previousInterval.end, queueTop.interval.start));
                   previousInterval = queueTop.interval;
               }else{
                   //overlapping interval; choose the next intterval
                   if(queueTop.interval.end > previousInterval.end){
                       previousInterval = queueTop.interval;
                   }
               }

               //if there are more intervals available for the same employee; add it to the heap

               var employeeSchedule = schedule[queueTop.employeeIndex];
               if(employeeSchedule.Count > queueTop.intervalIndex + 1){
                     minHeap.Add(new EmployeeInterval(employeeSchedule[queueTop.intervalIndex + 1],queueTop.employeeIndex,queueTop.intervalIndex + 1));

               }

           }

            return result;
        }
    }
}
