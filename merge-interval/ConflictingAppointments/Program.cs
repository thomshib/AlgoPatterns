using System;

namespace ConflictingAppointments
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
            Interval[] intervals = { new Interval(1, 4), new Interval(2, 5), new Interval(7, 9) };
            bool result = canAttendAllAppointments(intervals);
            Console.WriteLine("Can attend all appointments: " + result);

            Interval[] intervals1 = { new Interval(6, 7), new Interval(2, 4), new Interval(8, 12) };
            result =canAttendAllAppointments(intervals1);
            Console.WriteLine("Can attend all appointments: " + result);
        }

        public static bool canAttendAllAppointments(Interval[] intervals) {

            //sort array by start times
            Array.Sort(intervals, (a,b) => a.start.CompareTo(b.start));

            //find any overlapping interrval
            for(int i = 1; i < intervals.Length; i++){
                if(intervals[i-1].end > intervals[i].start){
                    return false;
                }

            }

            return true;

            
            
        }

    }
}
