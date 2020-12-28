https://www.educative.io/courses/grokking-the-coding-interview/R8DVgjq78yR

Given a string with lowercase letters only, if you are allowed to replace no more than ‘k’ letters with any letter, find the length of the longest substring having the same letters after replacement.

```
Input: String="aabccbb", k=2
Output: 5
Explanation: Replace the two 'c' with 'b' to have a longest repeating substring "bbbbb".

Input: String="abbcb", k=1
Output: 4
Explanation: Replace the 'c' with 'b' to have a longest repeating substring "bbbb".



Input: String="abccde", k=1
Output: 3
Explanation: Replace the 'b' or 'd' with 'c' to have the longest repeating substring "ccc".


```


This problem follows the Sliding Window pattern and we can use a similar dynamic sliding window strategy as discussed in No-repeat Substring. We can use a HashMap to count the frequency of each letter.

We’ll iterate through the string to add one letter at a time in the window. We’ll also keep track of the count of the maximum repeating letter in any window (let’s call it maxRepeatLetterCount). So at any time, we know that we can have a window which has one letter repeating maxRepeatLetterCount times, this means we should try to replace the remaining letters. If we have more than ‘k’ remaining letters, we should shrink the window as we are not allowed to replace more than ‘k’ letters.


https://www.educative.io/courses/grokking-the-coding-interview/B6VypRxPolJ

Given an array containing 0s and 1s, if you are allowed to replace no more than ‘k’ 0s with 1s, find the length of the longest contiguous subarray having all 1s.

```
Input: Array=[0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1], k=2
Output: 6
Explanation: Replace the '0' at index 5 and 8 to have the longest contiguous subarray of 1s having length 6.


Input: Array=[0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1], k=3
Output: 9
Explanation: Replace the '0' at index 6, 9, and 10 to have the longest contiguous subarray of 1s having length 9.


```


This problem follows the Sliding Window pattern and is quite similar to Longest Substring with same Letters after Replacement. The only difference is that, in the problem, we only have two characters (1s and 0s) in the input arrays.

Following a similar approach, we’ll iterate through the array to add one number at a time in the window. We’ll also keep track of the maximum number of repeating 1s in the current window (let’s call it maxOnesCount). So at any time, we know that we can have a window which has 1s repeating maxOnesCount time, so we should try to replace the remaining 0s. If we have more than ‘k’ remaining 0s, we should shrink the window as we are not allowed to replace more than ‘k’ 0s.