https://www.educative.io/courses/grokking-the-coding-interview/N8vB7OVYo2D

https://www.educative.io/courses/grokking-the-coding-interview/N0o9QnPLKNv

1. Given a string and a pattern, find out if the string contains any permutation of the pattern.
If a string has ‘n’ distinct characters it will have n!n!n! permutations.

```
Input: String="oidbcaf", Pattern="abc"
Output: true
Explanation: The string contains "bca" which is a permutation of the given pattern.


Input: String="odicf", Pattern="dc"
Output: false
Explanation: No permutation of the pattern is present in the given string as a substring.

Input: String="aaacb", Pattern="abc"
Output: true
Explanation: The string contains "acb" which is a permutation of the given pattern.


```


Solution
This problem follows the Sliding Window pattern and we can use a similar sliding window strategy as discussed in Longest Substring with K Distinct Characters. We can use a HashMap to remember the frequencies of all characters in the given pattern. Our goal will be to match all the characters from this HashMap with a sliding window in the given string. Here are the steps of our algorithm:

    Create a HashMap to calculate the frequencies of all characters in the pattern.
    Iterate through the string, adding one character at a time in the sliding window.
    If the character being added matches a character in the HashMap, decrement its frequency in the map. If the character frequency becomes zero, we got a complete match.
    If at any time, the number of characters matched is equal to the number of distinct characters in the pattern (i.e., total characters in the HashMap), we have gotten our required permutation.
    If the window size is greater than the length of the pattern, shrink the window to make it equal to the size of the pattern. At the same time, if the character going out was part of the pattern, put it back in the frequency HashMap.



2. String Anagrams 
Given a string and a pattern, find all anagrams of the pattern in the given string.

Anagram is actually a Permutation of a string. For example, “abc” has the following six anagrams:

    abc
    acb
    bac
    bca
    cab
    cba


```
Input: String="ppqp", Pattern="pq"
Output: [1, 2]
Explanation: The two anagrams of the pattern in the given string are "pq" and "qp".

Input: String="abbcabc", Pattern="abc"
Output: [2, 3, 4]
Explanation: The three anagrams of the pattern in the given string are "bca", "cab", and "abc".

```


3. Smallest Window containing Substring (hard) #

Given a string and a pattern, find the smallest substring in the given string which has all the characters of the given pattern.

```
Input: String="aabdec", Pattern="abc"
Output: "abdec"
Explanation: The smallest substring having all characters of the pattern is "abdec"



Input: String="abdabca", Pattern="abc"
Output: "abc"
Explanation: The smallest substring having all characters of the pattern is "abc".



Input: String="adcad", Pattern="abc"
Output: ""
Explanation: No substring in the given string has all characters of the pattern.

```