https://www.educative.io/courses/grokking-the-coding-interview/Y5n0n3vAgYK

Given an array of ‘K’ sorted LinkedLists, merge them into one sorted list.

```


Input: L1=[2, 6, 8], L2=[3, 6, 7], L3=[1, 3, 4]
Output: [1, 2, 3, 3, 4, 6, 6, 7, 8]
```

Solution


    We can insert the first element of each array in a Min Heap.
    After this, we can take out the smallest (top) element from the heap and add it to the merged list.
    After removing the smallest element from the heap, we can insert the next element of the same list into the heap.
    We can repeat steps 2 and 3 to populate the merged list in sorted order.

