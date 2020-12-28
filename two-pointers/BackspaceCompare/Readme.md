https://www.educative.io/courses/grokking-the-coding-interview/xVKE8MJDlzq

Given two strings containing backspaces (identified by the character ‘#’), check if the two strings are equal.
```
Input: str1="xy#z", str2="xzz#"
Output: true
Explanation: After applying backspaces the strings become "xz" and "xz" respectively.

Input: str1="xy#z", str2="xzz#"
Output: true
Explanation: After applying backspaces the strings become "xz" and "xz" respectively.

```

Solution #

To compare the given strings, first, we need to apply the backspaces. An efficient way to do this would be from the end of both the strings. We can have separate pointers, pointing to the last element of the given strings. We can start comparing the characters pointed out by both the pointers to see if the strings are equal. If, at any stage, the character pointed out by any of the pointers is a backspace (’#’), we will skip and apply the backspace until we have a valid character available for comparison.