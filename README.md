# Balanced Search Tree
Binary search tree is a data structure that quickly allows us to maintain a sorted list of numbers.

It is called a binary tree because each tree node has a maximum of two children.
It is called a search tree because it can be used to search for the presence of a number in O(log(n)) time.
The properties that separate a binary search tree from a regular binary tree is

All nodes of left subtree are less than the root node
All nodes of right subtree are more than the root node
Both subtrees of each node are also BSTs i.e. they have the above two properties

# Test Results
```
Insert in tree test
Set size = 100, Time: 1 ms, Time: 0.001 sec
Set size = 1000, Time: 0 ms, Time: 0 sec
Set size = 10000, Time: 15 ms, Time: 0.015 sec
Set size = 100000, Time: 186 ms, Time: 0.186 sec
Set size = 1000000, Time: 3672 ms, Time: 3.672 sec
Set size = 2000000, Time: 9130 ms, Time: 9.13 sec
Set size = 4000000, Time: 22640 ms, Time: 22.64 sec
Set size = 8000000, Time: 55261 ms, Time: 55.261 sec

Search tree test
Set size = 100, Time Avg: 0 ticks
Set size = 1000, Time Avg: 0 ticks
Set size = 10000, Time Avg: 0 ticks
Set size = 100000, Time Avg: 0 ticks
Set size = 1000000, Time Avg: 0 ticks
Set size = 2000000, Time Avg: 0 ticks
Set size = 4000000, Time Avg: 0 ticks
Set size = 8000000, Time Avg: 0 ticks

Remove tree test
Set size = 100, Time Avg: 12.2 ticks
Set size = 1000, Time Avg: 15.6 ticks
Set size = 10000, Time Avg: 18.4 ticks
Set size = 100000, Time Avg: 40 ticks
Set size = 1000000, Time Avg: 43.4 ticks
Set size = 2000000, Time Avg: 51.9 ticks
Set size = 4000000, Time Avg: 111.7 ticks
Set size = 8000000, Time Avg: 78.3 ticks
```