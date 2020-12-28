https://www.educative.io/courses/grokking-the-coding-interview/3jyVPKRA8yx


```
Intervals: [[6,7], [2,4], [5,9]]
Output: [[2,4], [5,9]]
Explanation: Since the intervals [6,7] and [5,9] overlap, we merged them into one [5,9].

```






    Sort the intervals on the start time to ensure a.start <= b.start
    If ‘a’ overlaps ‘b’ (i.e. b.start <= a.end), we need to merge them into a new interval ‘c’ such that:

    c.start = a.start
    c.end = max(a.end, b.end)

    We will keep repeating the above two steps to merge ‘c’ with the next interval if it overlaps with ‘c’.
