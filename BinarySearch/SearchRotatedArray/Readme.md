https://www.educative.io/courses/grokking-the-coding-interview/RMPVM2Y4PW0

Search in Rotated Array (medium) #

Given an array of numbers which is sorted in ascending order and also rotated by some arbitrary number, find if a given ‘key’ is present in it.

Write a function to return the index of the ‘key’ in the rotated array. If the ‘key’ is not present, return -1. You can assume that the given array does not have any duplicates.





Solution #

The problem follows the Binary Search pattern. We can use a similar approach as discussed in Order-agnostic Binary Search and modify it similar to Search Bitonic Array to search for the ‘key’ in the rotated array.

After calculating the middle, we can compare the numbers at indices start and middle. This will give us two options:

    If arr[start] <= arr[middle], the numbers from start to middle are sorted in ascending order.
    Else, the numbers from middle+1 to end are sorted in ascending order.

Once we know which part of the array is sorted, it is easy to adjust our ranges. For example, if option-1 is true, we have two choices:

    By comparing the ‘key’ with the numbers at index start and middle we can easily find out if the ‘key’ lies between indices start and middle; if it does, we can skip the second part => end = middle -1.
    Else, we can skip the first part => start = middle + 1.



----------------------------------------------------------------------------------

https://www.educative.io/courses/grokking-the-coding-interview/R1v4P0R7VZw

Rotation Count (medium) #

Given an array of numbers which is sorted in ascending order and is rotated ‘k’ times around a pivot, find ‘k’.

You can assume that the array does not have any duplicates.



Solution #

This problem follows the Binary Search pattern. We can use a similar strategy as discussed in Search in Rotated Array.

In this problem, actually, we are asked to find the index of the minimum element. The number of times the minimum element is moved to the right will be equal to the number of rotations. An interesting fact about the minimum element is that it is the only element in the given array which is smaller than its previous element. Since the array is sorted in ascending order, all other elements are bigger than their previous element.

After calculating the middle, we can compare the number at index middle with its previous and next number. This will give us two options:

    If arr[middle] > arr[middle + 1], then the element at middle + 1 is the smallest.
    If arr[middle - 1] > arr[middle], then the element at middle is the smallest.

To adjust the ranges we can follow the same approach as discussed in Search in Rotated Array. Comparing the numbers at indices start and middle will give us two options:

    If arr[start] < arr[middle], the numbers from start to middle are sorted.
    Else, the numbers from middle + 1 to end are sorted.
