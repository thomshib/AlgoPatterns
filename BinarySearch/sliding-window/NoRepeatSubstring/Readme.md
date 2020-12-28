https://www.educative.io/courses/grokking-the-coding-interview/YMzBx1gE5EO

Given a string, find the length of the longest substring which has no repeating characters.

```
Input: String="aabccbb"
Output: 3
Explanation: The longest substring without any repeating characters is "abc".

Input: String="abbbb"
Output: 2
Explanation: The longest substring without any repeating characters is "ab".

Input: String="abccde"
Output: 3
Explanation: Longest substrings without any repeating characters are "abc" & "cde".


```


This problem follows the Sliding Window pattern and we can use a similar dynamic sliding window strategy as discussed in Longest Substring with K Distinct Characters. We can use a HashMap to remember the last index of each character we have processed. Whenever we get a repeating character we will shrink our sliding window to ensure that we always have distinct characters in the sliding window.