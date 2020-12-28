https://www.educative.io/courses/grokking-the-coding-interview/qZgJyPqwJ80

Given a set of positive numbers, find the total number of subsets whose sum is equal to a given number ‘S’.

```


Input: {1, 1, 2, 3}, S=4
Output: 3
The given set has '3' subsets whose sum is '4': {1, 1, 2}, {1, 3}, {1, 3}
Note that we have two similar sets {1, 3}, because we have two '1' in our input.

```

Solution

for each number 'i' 
  create a new set which includes number 'i' if it does not exceed 'S', and recursively   
      process the remaining numbers and sum
  create a new set without number 'i', and recursively process the remaining numbers 
return the count of subsets who has a sum equal to 'S'

