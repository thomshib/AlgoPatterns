https://www.educative.io/courses/grokking-the-coding-interview/3Yj2BmpyEy4

Problem
Design a class to calculate the median of a number stream. The class should have the following two methods:

    insertNum(int num): stores the number in the class
    findMedian(): returns the median of all numbers inserted in the class

If the count of numbers inserted in the class is even, the median will be the average of the middle two numbers.


Solution

The best data structure that comes to mind to find the smallest or largest number among a list of numbers is a Heap. Let’s see how we can use a heap to find a better algorithm.

    We can store the first half of numbers (i.e., smallNumList) in a Max Heap. We should use a Max Heap as we are interested in knowing the largest number in the first half.
    We can store the second half of numbers (i.e., largeNumList) in a Min Heap, as we are interested in knowing the smallest number in the second half.
    Inserting a number in a heap will take O(logN)O(logN)O(logN), which is better than the brute force approach.
    At any time, the median of the current list of numbers can be calculated from the top element of the two heaps.


