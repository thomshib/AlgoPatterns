https://www.educative.io/courses/grokking-the-coding-interview/RMlGwgpoKKY

Given a binary tree and a number ‘S’, find if the tree has a path from root-to-leaf such that the sum of all the node values of that path equals ‘S’.

https://www.educative.io/courses/grokking-the-coding-interview/B815A0y2Ajn

Given a binary tree and a number ‘S’, find all paths from root-to-leaf such that the sum of all the node values of each path equals ‘S’.

Solution #

As we are trying to search for a root-to-leaf path, we can use the Depth First Search (DFS) technique to solve this problem.

To recursively traverse a binary tree in a DFS fashion, we can start from the root and at every step, make two recursive calls one for the left and one for the right child.

Here are the steps for our Binary Tree Path Sum problem:

    Start DFS with the root of the tree.
    If the current node is not a leaf node, do two things:
        Subtract the value of the current node from the given number to get a new sum => S = S - node.value
        Make two recursive calls for both the children of the current node with the new number calculated in the previous step.
    At every step, see if the current node being visited is a leaf node and if its value is equal to the given number ‘S’. If both these conditions are true, we have found the required root-to-leaf path, therefore return true.
    If the current node is a leaf but its value is not equal to the given number ‘S’, return false.




https://www.educative.io/courses/grokking-the-coding-interview/xV2J7jvN1or

Given a binary tree and a number ‘S’, find all paths in the tree such that the sum of all the node values of each path equals ‘S’. Please note that the paths can start or end at any node but all paths must follow direction from parent to child (top to bottom).



Solution #

This problem follows the Binary Tree Path Sum pattern. We can follow the same DFS approach. But there will be four differences:

    We will keep track of the current path in a list which will be passed to every recursive call.

    Whenever we traverse a node we will do two things:
        Add the current node to the current path.
        As we added a new node to the current path, we should find the sums of all sub-paths ending at the current node. If the sum of any sub-path is equal to ‘S’ we will increment our path count.

    We will traverse all paths and will not stop processing after finding the first path.

    Remove the current node from the current path before returning from the function. This is needed to Backtrack while we are going up the recursive call stack to process other paths.

