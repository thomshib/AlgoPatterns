https://www.educative.io/courses/grokking-the-coding-interview/JP8VKGOEpXl

Given an array of intervals, find the next interval of each interval. In a list of intervals, for an interval ‘i’ its next interval ‘j’ will have the smallest ‘start’ greater than or equal to the ‘end’ of ‘i’.

Write a function to return an array containing indices of the next interval of each input interval. If there is no next interval of a given interval, return -1. It is given that none of the intervals have the same start point.


Solution

We can utilize the Two Heaps approach. We can push all intervals into two heaps: one heap to sort the intervals on maximum start time (let’s call it maxStartHeap) and the other on maximum end time (let’s call it maxEndHeap). We can then iterate through all intervals of the `maxEndHeap’ to find their next interval. Our algorithm will have the following steps:

    Take out the top (having highest end) interval from the maxEndHeap to find its next interval. Let’s call this interval topEnd.
    Find an interval in the maxStartHeap with the closest start greater than or equal to the start of topEnd. Since maxStartHeap is sorted by ‘start’ of intervals, it is easy to find the interval with the highest ‘start’. Let’s call this interval topStart.
    Add the index of topStart in the result array as the next interval of topEnd. If we can’t find the next interval, add ‘-1’ in the result array.
    Put the topStart back in the maxStartHeap, as it could be the next interval of other intervals.
    Repeat the steps 1-4 until we have no intervals left in maxEndHeap.
