https://www.educative.io/courses/grokking-the-coding-interview/g7QYlD8RwRr

Given a set of positive numbers, find if we can partition it into two subsets such that the sum of elements in both subsets is equal.

```

Input: {1, 2, 3, 4}
Output: True
Explanation: The given set can be partitioned into two subsets with equal sum: {1, 4} & {2, 3}

```

Solution:
Assume that S represents the total sum of all the given numbers. Then the two equal subsets must have a sum equal to S/2. This essentially transforms our problem to: "Find a subset of the given numbers that has a total sum of S/2".


for each number 'i' 
  create a new set which INCLUDES number 'i' if it does not exceed 'S/2', and recursively 
      process the remaining numbers
  create a new set WITHOUT number 'i', and recursively process the remaining items 
return true if any of the above sets has a sum equal to 'S/2', otherwise return false


--------------------------------------------------------------------------------------------------
https://www.educative.io/courses/grokking-the-coding-interview/mE53y85Wqw9

Given a set of positive numbers, partition the set into two subsets with minimum difference between their subset sums.

```
Input: {1, 3, 100, 4}
Output: 92
Explanation: We can partition the given set into two subsets where minimum absolute difference 
between the sum of numbers is '92'. Here are the two subsets: {1, 3, 4} & {100}.
```

Let’s assume S1 and S2 are the two desired subsets. A basic brute-force solution could be to try adding each element either in S1 or S2 in order to find the combination that gives the minimum sum difference between the two sets.

So our brute-force algorithm will look like:

for each number 'i' 
  add number 'i' to S1 and recursively process the remaining numbers
  add number 'i' to S2 and recursively process the remaining numbers
return the minimum absolute difference of the above two sets 