#  https://codeforces.com/problemset/problem/750/A
#
# to solve this task you neeed to solve inequation:
# 5(f+1)*f/2 <= p AND 0<=f<=n f can be found with binary search
# f(f+1) <= 2/5*(240-k) AND 0<=f<=n

import math

def solution(n, k):
    total_time =4*60
    limit_time_for_tasks = total_time - k
    L = 0
    R = n
    while L <= R:
        s = math.floor((L+R)/2)
        if s==n:
            return n
        s_solve_time = 5*s*(s+1)/2
        s1_solve_time = 5*(s+1)*(s+2)/2
        if s_solve_time <= limit_time_for_tasks:
            if s1_solve_time <= limit_time_for_tasks:
                L = s+1
            else:
                return s
        else: # s_solve_time > limit_time_for_tasks:
            R = s - 1
        
            
if __name__ == '__main__':
    (n, k) = map(int, input().split())
    print(solution(n,k))

    # print ('Start tests..')
    # assert solution(3,222) == 2
    # assert solution(4,190) == 4
    # assert solution(7,1) == 7
    # assert solution(1,1) == 1
    # print ('passed!')