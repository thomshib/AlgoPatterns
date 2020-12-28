https://www.educative.io/courses/grokking-the-coding-interview/xVoBRZz7RwP


https://miafish.wordpress.com/2015/03/16/c-min-heap-implementation/ - Heap

Given a list of intervals representing the start and end time of ‘N’ meetings, find the minimum number of rooms required to hold all the meetings.

```
Meetings: [[1,4], [2,5], [7,9]]
Output: 2
Explanation: Since [1,4] and [2,5] overlap, we need two rooms to hold these two meetings. [7,9] can 
occur in any of the two rooms later.

```


So our algorithm will look like this:

    Sort all the meetings on their start time.
    Create a min-heap to store all the active meetings. This min-heap will also be used to find the active meeting with the smallest end time.
    Iterate through all the meetings one by one to add them in the min-heap. Let’s say we are trying to schedule the meeting m1.
    Since the min-heap contains all the active meetings, so before scheduling m1 we can remove all meetings from the heap that have ended before m1, i.e., remove all meetings from the heap that have an end time smaller than or equal to the start time of m1.
    Now add m1 to the heap.
    The heap will always have all the overlapping meetings, so we will need rooms for all of them. Keep a counter to remember the maximum size of the heap at any time which will be the minimum number of rooms needed.
