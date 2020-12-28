https://www.educative.io/courses/grokking-the-coding-interview/N0Q3PKRKMPz

Given an expression containing digits and operations (+, -, *), find all possible ways in which the expression can be evaluated by grouping the numbers and operators using parentheses.



Solution
This problem follows the Subsets pattern and can be mapped to Balanced Parentheses. We can follow a similar BFS approach.

Let’s take Example-1 mentioned above to generate different ways to evaluate the expression.

    We can iterate through the expression character-by-character.
    we can break the expression into two halves whenever we get an operator (+, -, *).
    The two parts can be calculated by recursively calling the function.
    Once we have the evaluation results from the left and right halves, we can combine them to produce all results.
