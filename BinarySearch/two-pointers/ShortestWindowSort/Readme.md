https://www.educative.io/courses/grokking-the-coding-interview/gxL951y9xj3

Given an array, find the length of the smallest subarray in it which when sorted will sort the whole array.

```
Input: [1, 2, 5, 3, 7, 10, 9, 12]
Output: 5
Explanation: We need to sort only the subarray [5, 3, 7, 10, 9] to make the whole array sorted

Input: [1, 2, 3]
Output: 0
Explanation: The array is already sorted

Input: [3, 2, 1]
Output: 3
Explanation: The whole array needs to be sorted.
```


As we know, once an array is sorted (in ascending order), the smallest number is at the beginning and the largest number is at the end of the array. So if we start from the beginning of the array to find the first element which is out of sorting order i.e., which is smaller than its previous element, and similarly from the end of array to find the first element which is bigger than its previous element, will sorting the subarray between these two numbers result in the whole array being sorted?



    From the beginning and end of the array, find the first elements that are out of the sorting order. The two elements will be our candidate subarray.
    Find the maximum and minimum of this subarray.
    Extend the subarray from beginning to include any number which is bigger than the minimum of the subarray.
    Similarly, extend the subarray from the end to include any number which is smaller than the maximum of the subarray.
