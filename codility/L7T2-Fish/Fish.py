# TASK:
# You are given two non-empty arrays A and B consisting of N integers. Arrays A and B represent N voracious fish in a river, ordered downstream along the flow of the river.

# The fish are numbered from 0 to N − 1. If P and Q are two fish and P < Q, then fish P is initially upstream of fish Q. Initially, each fish has a unique position.

# Fish number P is represented by A[P] and B[P]. Array A contains the sizes of the fish. All its elements are unique. Array B contains the directions of the fish. It contains only 0s and/or 1s, where:

# 0 represents a fish flowing upstream,
# 1 represents a fish flowing downstream.
# If two fish move in opposite directions and there are no other (living) fish between them, they will eventually meet each other. Then only one fish can stay alive − the larger fish eats the smaller one. More precisely, we say that two fish P and Q meet each other when P < Q, B[P] = 1 and B[Q] = 0, and there are no living fish between them. After they meet:

# If A[P] > A[Q] then P eats Q, and P will still be flowing downstream,
# If A[Q] > A[P] then Q eats P, and Q will still be flowing upstream.
# We assume that all the fish are flowing at the same speed. That is, fish moving in the same direction never meet. The goal is to calculate the number of fish that will stay alive.

# For example, consider arrays A and B such that:

#   A[0] = 4    B[0] = 0
#   A[1] = 3    B[1] = 1
#   A[2] = 2    B[2] = 0
#   A[3] = 1    B[3] = 0
#   A[4] = 5    B[4] = 0
# Initially all the fish are alive and all except fish number 1 are moving upstream. Fish number 1 meets fish number 2 and eats it, then it meets fish number 3 and eats it too. Finally, it meets fish number 4 and is eaten by it. The remaining two fish, number 0 and 4, never meet and therefore stay alive.

# Write a function:

# def solution(A, B)

# that, given two non-empty arrays A and B consisting of N integers, returns the number of fish that will stay alive.

# For example, given the arrays shown above, the function should return 2, as explained above.

# Write an efficient algorithm for the following assumptions:

# N is an integer within the range [1..100,000];
# each element of array A is an integer within the range [0..1,000,000,000];
# each element of array B is an integer that can have one of the following values: 0, 1;
# the elements of A are all distinct.

# ANALYSIS:
# possible situations:
#    current  next id
#       ->     ->  1
#       ->     <-  2
#       <-     ->  3
#       <-     <-  4
# every value is different so for id 2 battle always win one fish
# if we analyze along river stream:
# all fishes going upstream if not downstream fishes can live safely
# if any fishes going downstream meet fish going upstrem then  is the fight
# order of fishes going downstream is important so put them on stack preserving this
# We can notice that fish put on downstream will be allways stay alive (consume fish going upstream) or die so complexity is O(N)

# SOLUTION: https://app.codility.com/demo/results/trainingXQHG5T-JY5/

def solution(A, B):
    downstream = []
    upstream_count = 0

    for i in range(len(A)):
        if B[i] == 1:                       # -> ??
            downstream.append(A[i])
        else:
            upstream_count += 1             # <- ??
            while downstream:
                top = downstream.pop()
                if top > A[i]:
                    downstream.append(top)
                    upstream_count -=1
                    break
                else:
                    continue

    return len(downstream) + upstream_count


if __name__ == '__main__':
    print('Start tests..')

    # edge
    assert solution([0],[0]) == 1
    assert solution([0],[1]) == 1
    # different weight fish 
    assert solution([1,0],[0,0]) == 2
    assert solution([1,0],[0,1]) == 2
    assert solution([1,0],[1,0]) == 1
    assert solution([1,0],[1,1]) == 2
    # different weight fish 
    assert solution([0,1],[0,0]) == 2
    assert solution([0,1],[0,1]) == 2
    assert solution([0,1],[1,0]) == 1
    assert solution([0,1],[1,1]) == 2
    # big fish eat all
    assert solution([10,9,8,7,6,5,4],[1,0,0,0,0,0,0]) == 1
    assert solution([4,5,6,7,8,9,10],[1,1,1,1,1,1,0]) == 1
    # other
    assert solution([4,3,2,1,5],[0,1,0,0,0]) == 2
    assert solution([5,4,3,2,1],[0,0,0,0,0]) == 5
    assert solution([5,4,3,2,1],[1,0,0,0,0]) == 1
    assert solution([5,4,3,2,1],[1,0,0,0,0]) == 1
    assert solution([5,4,3,2,1],[0,0,0,1,1]) == 5
    assert solution([5,4,3,2,1],[1,1,0,1,1]) == 4
    assert solution([5,4,3,2,1],[0,0,1,0,0]) == 3
    assert solution([5,4,3,2,1],[1,1,1,0,0]) == 3
    #downsream order
    assert solution([5,8,2,1,4],[1,1,1,1,0]) == 2

    print ('passed!')