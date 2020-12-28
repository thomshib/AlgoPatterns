https://www.educative.io/courses/grokking-the-coding-interview/JExVVqRAN9D
Given two lists of intervals, find the intersection of these two lists. Each list consists of disjoint intervals sorted on their start time.


```
Input: arr1=[[1, 3], [5, 6], [7, 9]], arr2=[[2, 3], [5, 7]]
Output: [2, 3], [5, 6], [7, 7]
Explanation: The output list contains the common intervals between the two lists.


```


the overlapping interval will be equal to:

    start = max(a.start, b.start)
    end = min(a.end, b.end) 

That is, the highest start time and the lowest end time will be the overlapping interval.

So our algorithm will be to iterate through both the lists together to see if any two intervals overlap. If two intervals overlap, we will insert the overlapped part into a result list and move on to the next interval which is finishing early.