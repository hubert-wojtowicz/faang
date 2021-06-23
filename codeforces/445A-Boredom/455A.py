# https://codeforces.com/problemset/submission/455/116602461
# https://codeforces.com/problemset/problem/455/A
#
# 1 <= n, a_k <= 10^5
# Observation:
# 1) order of elements in collection does not matter
# 2) i=a_k, let say c(i) is number of occurance of value i.
# 3) then solution is f(max(a_1, ...,a_n)), where f(i) is some formula giving winning value in game (assume that formula exist)
# 4) if we pick geatest value in collection a_k we can generate decision three like
#    for every value i we take maximum of two possible choices:
#    (a) we go to value smaller by one f(i-1) 
#    (b) we select current value removing neghboorhood f(i-2) + c(i)*i
# if we reached value a_k=1 we take it as it is component of winning stratefgy c(1)*1. 
# Assume just for securing edge case we state f(0)=0 (this is because (b) jumps by 2).
#
# We get beautiful, tricki formula: 
# f(i) = max(f(i - 1), f(i - 2) + c(i]·i), 2 ≤ i ≤ n; (optimal substructure it is called in dynamic programming)
# f(1) = cnt[1];
# f(0) = 0;
#
# The game answer is f(max(a1,a2,...,ak)).
# Once we see this recurence we can build F arrary where F=[f(0),f(1),f(2),...f(max(a_1,...,a_n))] in linear time.
# For optimization of memory F can be rrepresented as Dictionary.
# 
# Complexity:
# c(i) calculation with hash table (dictionary) is O(n) time
# building F dictionary it is can be estimated by O(n)
# 
# Observation:
# No point in keeping wholr Fn. It is just enough to keep 3 last values of F... 
#

from collections import Counter, defaultdict

def solution(A):
    amax = max(A)
    C = dict(Counter(A))
    if len(C)==1:
        return C[amax]*amax
    F0 = 0
    F1 = C[1] if (1 in C) else 0
    F = 0
    a = 2
    while a <= amax:
        ca = C[a] if a in C else 0
        F = max(F1, F0 + ca*a)
        F0 = F1
        F1 = F
        a += 1
    return F

        
is_test = False
if __name__ == '__main__':
    if is_test:
        print ('Start tests..')
        assert solution([1]) == 1
        assert solution([1, 1]) == 2
        assert solution([1, 2]) == 2
        assert solution([1, 2, 3]) == 4
        assert solution([1, 2, 1, 3, 2, 2, 2, 2, 3]) == 10
        assert solution([1, 2, 1, 3, 2, 2, 2, 2, 3, 4, 4]) == 18
        assert solution([6, 6, 8, 9, 7, 9, 6, 9, 5, 7, 7, 4, 5, 3, 9, 1, 10, 3, 4, 5, 8, 9, 6, 5, 6, 4, 10, 9, 1, 4, 1, 7, 1, 4, 9, 10, 8, 2, 9, 9, 10, 5, 8, 9, 5, 6, 8, 7, 2, 8, 7, 6, 2, 6, 10, 8, 6, 2, 5, 5, 3, 2, 8, 8, 5, 3, 6, 2, 1, 4, 7, 2, 7, 3, 7, 4, 10, 10, 7, 5, 4, 7, 5, 10, 7, 1, 1, 10, 7, 7, 7, 2, 3, 4, 2, 8, 4, 7, 4, 4]) == 296
        print ('passed!')

    n = input()
    A = list(map(int, input().split(' ')))
    print(solution(A))