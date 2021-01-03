# https://app.codility.com/programmers/lessons/17-dynamic_programming/number_solitaire/
# This is dynamic programming problem. We need solve recursion:
# dp[n-1] = A[n-1] + max(dp[n-1-1],...dp[n-1-k]), where 1<=k<=6 and n-1-k >= 0
# dp[0] = A[0]

# First try top-bottom method as it is easy.
# Then if not satisfy requirement let use bottom-up method to save memory and do not use recursion.

# for N [2..100,000] and Ai in [−10,000..10,000] where 0 <= i < N
# max sum is 100,000*10,000 = 10^9 what can be handle by int
# Solution: https://app.codility.com/demo/results/training8VNZ5G-XFY/

def solution(A):
    queue = [A[0]]
    for (_,a) in enumerate(A[1:]):
        queue.append(max(queue)+a)
        if len(queue) > 6:
            queue.pop(0)

    return queue[-1] 


if __name__ == '__main__':
    print ('Start tests..')
    assert solution([-2,0,4,7,0,0,-10,-2,4,0,9,-2]) == 20
    assert solution([1,-2,0,9,-1,-2]) == 8
    assert solution([1, 1]) == 2
    
    assert solution([0, 0]) == 0
    assert solution([1,0,0,3]) == 4
    print ('passed!')