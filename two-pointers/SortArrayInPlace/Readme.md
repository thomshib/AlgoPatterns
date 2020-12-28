https://www.educative.io/courses/grokking-the-coding-interview/RMBxV6jz6Q0

Problem Statement #

Given an array containing 0s, 1s and 2s, sort the array in-place. You should treat numbers of the array as objects, hence, we can’t count 0s, 1s, and 2s to recreate the array.

```
Input: [1, 0, 2, 1, 0]
Output: [0 0 1 1 2]

Input: [2, 2, 0, 1, 2, 0]
Output: [0 0 1 2 2 2 ]

```


We can use a Two Pointers approach while iterating through the array. Let’s say the two pointers are called low and high which are pointing to the first and the last element of the array respectively. So while iterating, we will move all 0s before low and all 2s after high so that in the end, all 1s will be between low and high.


Solution 
1. Keep three indices low = 1, mid = 1 and high = N and there are four ranges, 1 to low (the range containing 0), low to mid (the range containing 1), mid to high (the range containing unknown elements) and high to N (the range containing 2).
2. Traverse the array from start to end and mid is less than high. (Loop counter is i)
3. If the element is 0 then swap the element with the element at index low and update low = low + 1 and mid = mid + 1
4. If the element is 1 then update mid = mid + 1
5. If the element is 2 then swap the element with the element at index high and update high = high – 1 and update i = i – 1. As the swapped element is not processed