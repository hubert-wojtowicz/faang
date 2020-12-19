# https://codeforces.com/problemset/problem/910/A
#
# Solution is to jump to farest lilie every time.
# If imagine we have 3 lilies in order on Ox axis: A, B, C in some distances between them.
# Notice if C is reachable from A then then it is reachable from B as distance from B to C is shorter than from A to C.
# Time complexity upper bounded with O(n) - every time jump by 1. Maybe there is better limit, but this one seems to be satisfactory.


def solution(n, d, L):
    current_pos = 0
    jumps = 0
    while current_pos < n-1:
        longest_jump = min(d, n-1-current_pos)

        while L[current_pos + longest_jump] != '1' and longest_jump >= 0:
            longest_jump -= 1

        if longest_jump == 0:
            return -1
        
        current_pos += longest_jump
        jumps += 1
            
    return jumps

        
            
if __name__ == '__main__':
    (n, k) = map(int, input().split())
    L = input()
    print(solution(n,k,L))

    # print ('Start tests..')
    # assert solution(8,4,'10010101') == 2
    # assert solution(4,2,'1001') == -1
    # assert solution(8,4,'11100101') == 3
    # assert solution(12, 3, '101111100101') == 4
    # assert solution(2, 1, '11') == 1
    # assert solution(3, 1, '101') == -1
    # assert solution(3, 2, '101') == 1
    
    print ('passed!')