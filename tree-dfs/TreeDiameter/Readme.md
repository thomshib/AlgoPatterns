https://www.educative.io/courses/grokking-the-coding-interview/xVV1jA29YK9


Given a binary tree, find the length of its diameter. The diameter of a tree is the number of nodes on the longest path between any two leaf nodes. The diameter of a tree may or may not pass through the root.

Note: You can always assume that there are at least two leaf nodes in the given tree.


Solution

This problem follows the Binary Tree Path Sum pattern. We can follow the same DFS approach. There will be a few differences:

    At every step, we need to find the height of both children of the current node. For this, we will make two recursive calls similar to DFS.
    The height of the current node will be equal to the maximum of the heights of its left or right children, plus ‘1’ for the current node.
    The tree diameter at the current node will be equal to the height of the left child plus the height of the right child plus ‘1’ for the current node: diameter = leftTreeHeight + rightTreeHeight + 1. To find the overall tree diameter, we will use a class level variable. This variable will store the maximum diameter of all the nodes visited so far, hence, eventually, it will have the final tree diameter.
