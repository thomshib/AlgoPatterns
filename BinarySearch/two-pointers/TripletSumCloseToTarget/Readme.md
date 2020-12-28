https://www.educative.io/courses/grokking-the-coding-interview/3YlQz7PE7OA

Given an array of unsorted numbers and a target number, find a triplet in the array whose sum is as close to the target number as possible, return the sum of the triplet. If there are more than one such triplet, return the sum of the triplet with the smallest sum.

```
Input: [-2, 0, 1, 2], target=2
Output: 1
Explanation: The triplet [-2, 1, 2] has the closest sum to the target.
https://www.youtube.com/watch?v=_diMDpuEYBM



Input: [2, -3, 4, -2], target=1
Triplets are  ------  Triplet Sum  -- Abs(target - TripletSum)
    [-3,-2,4] ------    1          --    2
    [-3,-2,2] ------   -3          --    4
    [-3,2,4]  ------    3          --    2
    [-2,2,4]  ------    4          --    3

```