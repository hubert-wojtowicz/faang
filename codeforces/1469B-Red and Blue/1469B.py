# https://codeforces.com/problemset/problem/1469/B
# https://codeforces.com/problemset/submission/1469/120399560
# 
# Introduce two pointers i and j for red end blue position pointing.
# observations
# 1. whenever i o j is moved all previous elements are components of sum
# 2. defining prefix sum we can see maximal component sum for both red and blue
# 3. order of insertion to prefix sum does not matter - sum has the same value independent of insertion order
# 4. f(a) can be maximal value of 0, MPR, MPB, MPR+MPB, where:
# MPR - max prefix sum value build of Red sequence 
# MPB - max prefix sum value build of Blue sequence 
# Complexity O(n+m)

from itertools import accumulate 
if __name__ == '__main__':
    t = int(input())
    while t>0:
        t-=1
        n = input()
        MPR=max(accumulate(map(int, input().split(' '))))
        m = input()
        MPB=max(accumulate(map(int, input().split(' '))))
        print(max(0, MPR, MPB, MPR+MPB))