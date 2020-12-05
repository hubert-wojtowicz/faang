# PROBLEM:
# fint leader in collection understood as element of count greated than N/2
# N[0..100,000]
# A[i] where 0<=i<N is [−2,147,483,648..2,147,483,647]
# ANALISYS:
# This is typical leader problem.
# Noticing that removal of pair different numbers from collection doesn't change leader is main observation.
# This can be proved with definition and assumption tha in worst case we loose one item of leader while removing 2 different elements from source collection, so
# Def is: If ⌊n/2⌋ < L_n, then L_n is called leader. 
# Assume there is leader at the begining so definition is true.
# L_(n-2)+1 = L_n in worst case removing two different numbers fron collection of n numbers.
# ⌊(n-2)/2⌋ < L_(n-2) = L_n - 1 
# ⌊n/2-2/2⌋ < L_n - 1
# ⌊n/2⌋-1 < L_n - 1
# so we received def ⌊n/2⌋ < L_n Q.E.D.
# This allows us to solve this in O(n) time.
# Probably sorting arrary O(n*lg2(n)) and checking element at middle posiion would work as well for N=100,000 but let's be extraordinary precise :). 
# SOLUTION: https://app.codility.com/demo/results/trainingW5QWQE-R8Z/

def solution(A):
    size = 0
    for i, a in enumerate(A):
        if size > 0:
            if a == value:
                size += 1
            else:
                size -= 1
        else:
            value = a
            size = 1

    count = 0
    idx = -1
    for i, a in enumerate(A):
        if A[i] == value:
            count += 1
            idx = i

    return idx if count > (len(A) // 2) else -1

if __name__ == '__main__':
    print ('Start tests..')
    assert solution([]) == -1
    assert solution([1]) == 0
    assert solution([-1,1]) == -1
    assert solution([-1,1,-1]) == 2
    assert solution([8,4,1,4,2,4,4]) == 6
    print ('passed!')