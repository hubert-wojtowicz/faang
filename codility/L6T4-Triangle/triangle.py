# A triplet (P, Q, R) is triangular if 0 ≤ P < Q < R < N and:

# A[P] + A[Q] > A[R],
# A[Q] + A[R] > A[P],
# A[R] + A[P] > A[Q].

# Given an array A consisting of N integers, returns 1 if there exists a triangular triplet for this array and returns 0 otherwise.

# N is an integer within the range [0..100,000];
# each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].
# if we sort array then a_p < a_q < a_r for 0 ≤ p < q < r < N 
# beacause of that we automatically know:
# a_r + a_p > a_q
# a_r + a_q > a_p, because a_r is the biggest in tripple
# remaining condition:
# a_p + a_q > a_r
# if those p,q,r indexes are consecutive there is no point in checking lower indices.
# Assume p,q,r are not consecutive, then 2 first inequation still fulfilled, but if triangle exist the highest q and p indices allways will fulfill remaining inequation.
# Sorting is in O(N*lg2(N)) and check is O(N) so algorithm is O(N)

# Solution: https://app.codility.com/demo/results/training8DVDRJ-BWP/

def solution(A):
    A.sort()
    triples = [A[i:i+3] for i in range(len(A) - 3 + 1)]
    for p,q,r in triples:
        if (p + q > r):
            return 1
    return 0


if __name__ == '__main__':
    print('Start tests..')

    assert solution([10, 2, 5, 1, 8, 20]) == 1
    assert solution([10, 50, 5, 1]) == 0
    assert solution([]) == 0
    assert solution([1]) == 0
    assert solution([1,1]) == 0
    assert solution([1,1,1]) == 1
    print ('passed!')