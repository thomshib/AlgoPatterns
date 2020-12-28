https://www.educative.io/courses/grokking-the-coding-interview/RMV1GV1yPYz

Given an array with positive numbers and a target number, find all of its contiguous subarrays whose product is less than the target number.

```
Input: [2, 5, 3, 10], target=30 
Output: [2], [5], [2, 5], [3], [5, 3], [10]
Explanation: There are six contiguous subarrays whose product is less than the target.

```


Solution #

This problem follows the Sliding Window and the Two Pointers pattern and shares similarities with Triplets with Smaller Sum with two differences:

    In this problem, the input array is not sorted.
    Instead of finding triplets with sum less than a target, we need to find all subarrays having a product less than the target.

The implementation will be quite similar to Triplets with Smaller Sum.


Solution #2
https://www.geeksforgeeks.org/number-subarrays-product-less-k/

Assume, we have a window between start and end, and the product of all elements of it is p < k. Now, let's try to add a new element x. There are two possible cases.

Case 1. p*x < k
This means we can move the window’s right bound one step further. How many contiguous arrays does this step produce? It is: 1 + (end-start).

Indeed, the element itself comprises an array, and also we can add x to all contiguous arrays which have right border at end. There are as many such arrays as the length of the window.

Case 2. p*x >= k

This means we must first adjust the window’s left border so that the product is again less than k. After that, we can apply the formula from Case 1.

````
a = [5, 3, 2]
  k = 16
 
  counter = 0
  Window: [5]
  Product: 5

  5  counter += 1+ (0-0)
  counter = 1
  Window: [5,3]
  Product: 15

  15  counter += 1 + (1-0)
  counter = 3
  Window: [5,3,2]
  Product: 30

  30 > 16 --> Adjust the left border
  New Window: [3,2]
  New Product: 6

  6  counter += 1 + (2-1)
  counter = 5
  Answer: 5



```