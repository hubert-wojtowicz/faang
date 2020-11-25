#  The discs are numbered from 0 to N − 1. An array A of N non-negative integers, specifying the radiuses of the discs, is given. The J-th disc is drawn with its center at (J, 0) and radius A[J].
#  We say that the J-th disc and K-th disc intersect if J ≠ K and the J-th and K-th discs have at least one common point (assuming that the discs contain their borders).
#  Return the number of (unordered) pairs of intersecting discs. The function should return −1 if the number of intersecting pairs exceeds 10,000,000.
#  N is an integer within the range [0..100,000];
#  each element of array A is an integer within the range [0..2,147,483,647].
#  ----
#  Unordered means we do not count j and k intersection relaction twice. To be precise intersection J and K (J ≠ K) is the same as intersection K and J.
#  
#  Remembering law ¬(P⇒Q)⟺ P∧¬Q.
#  
#  By saying "no intersection" noticing that then j<k => j+A[j] < k-A[k] and negation it we can have:
#  intersection for j < k => j+A[j] >= k-A[k]
#  Having this we can find all intersection for every element for j = 0,...,N-1
#  Straigthforwar algorithm require in worst case O(N^2 - (1+N)N/2) = O(0.5(N^2-1)) = O(N^2) checks.
#
#  W can notice we can count active circle at i position and aggregate them. This way we will not repeat counting.
#  Elegant solution proposed here http://www.lucainvernizzi.net/blog/2014/11/21/codility-beta-challenge-number-of-disc-intersections/
#  This time I had to follow this guy solution.
#  By trhe way he inspired me to do pyhon in those contest as .NET on Codility is very old 4.5 Mono distro...
    
def solution(A):
    events = []
    for i, a in enumerate(A):
        events += [(i - a, 1), (i + a, -1)]
    events.sort(key=lambda x: (x[0], -x[1]))
    intersections, active = 0, 0
    for _, count in events:
        intersections += active * (count > 0)
        active += count
        if intersections > 10E6:
            return -1
    return intersections


if __name__ == '__main__':
    print ('Start tests..')
    assert solution([1, 5, 2, 1, 4, 0]) == 11
    assert solution([]) == 0
    assert solution([0,1]) == 1
    assert solution([0, 0]) == 0
    assert solution([1,0,0,3]) == 4
    print ('passed!')