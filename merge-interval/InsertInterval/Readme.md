https://www.educative.io/courses/grokking-the-coding-interview/3jKlyNMJPEM

```

Input: Intervals=[[1,3], [5,7], [8,12]], New Interval=[4,6]
Output: [[1,3], [4,7], [8,12]]
Explanation: After insertion, since [4,6] overlaps with [5,7], we merged them into one [4,7].

```


    1. Skip all intervals which end before the start of the new interval, i.e., skip all intervals with the following condition:

    intervals[i].end < newInterval.start

    2. Let’s call the last interval ‘b’ that does not satisfy the above condition. If ‘b’ overlaps with the new interval (a) (i.e. b.start <= a.end), we need to merge them into a new interval ‘c’:

    c.start = min(a.start, b.start)
    c.end = max(a.end, b.end)

    3. We will repeat the above two steps to merge ‘c’ with the next overlapping interval.
