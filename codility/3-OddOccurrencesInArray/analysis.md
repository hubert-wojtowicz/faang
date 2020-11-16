# Assumption analisys:

Based on provided input solution allways exist. 
The most edge case is one item in array, then answer is allways this number.
The second edge case is three numbers in array. Here we have one unparied and 2 left.
And so on...

# We can solve this in many ways.

Brute force - for each element check if any pair exit in fornt. If pair does not exist then found answer. Time complexity for this approach is O(n(n-1)/2)=O(n^2). For N=1000000 this is far not enough.

Another solution is sorting array and watching neghbourhood. Unpaired element will have no equal element next to it. It has time complexity O(n*lg2(n)) with O(lg2(n)) memory - QuickSort. 

Better solutuin allowing for linear tine conplexity O(n) is creating 1 000 000 000 short array. This helper array will cost ~952MB of memeory. At the begining we initialize all of this array elements with 0. Then when we find value we increase value. At the end we traverse array to find 1 value. 1 means this array value is unpaired.

# Remarks:
1) I forgot it can be case 
2 2 2 
where answer is 2...

2) I used dictionary instead of contiguous block of memory has as allocation occurred to have non-negligible impact on performance.git st