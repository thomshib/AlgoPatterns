using System;
using System.Collections.Generic;
using DataStructures;

namespace MinimumMeetingRooms
{
    class Meeting : IComparable<Meeting>
    {
        public int start;
        public int end;

        public Meeting(int start, int end) {
            this.start = start;
            this.end = end;
        }
        public int CompareTo(Meeting other){
            return this.start.CompareTo(other.start);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Meeting> input = new List<Meeting>() 
            {
                new Meeting(4, 5),
                new Meeting(2, 3),
                new Meeting(2, 4),
                new Meeting(3, 5)
            };
    
            int result = findMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

            input = new List<Meeting>() 
            {
                new Meeting(6, 7),
                new Meeting(2, 4),
                new Meeting(8, 12)
            };
    
            result = findMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);
        }

         public static int findMinimumMeetingRooms(List<Meeting> meetings) {
             if (meetings == null || meetings.Count == 0)
                return 0;


             //sort by meeting start time
            meetings.Sort( (a,b) => a.start.CompareTo(b.start) );

            Heap<Meeting> minHeap = new Heap<Meeting>();



            int roomCount = 0;
            foreach(var item in meetings){
                //remove all meetings that have ended
                while(minHeap.GetSize() > 0 && item.start >= minHeap.Peek().end){
                    minHeap.Pop();
                }

                //add the current meeting to the heap
                minHeap.Add(item);

                //all active meetings are in the heap
                roomCount = Math.Max(roomCount, minHeap.GetSize());


            }

            return roomCount;
        }
    }
}
