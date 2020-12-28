https://www.educative.io/courses/grokking-the-coding-interview/mErolRNQ00R



Solution #

Another way of defining the rotation is to take the sub-list of ‘k’ ending nodes of the LinkedList and connect them to the beginning. Other than that we have to do three more things:

    Connect the last node of the LinkedList to the head, because the list will have a different tail after the rotation.
    The new head of the LinkedList will be the node at the beginning of the sublist.
    The node right before the start of sub-list will be the new tail of the rotated LinkedList.
