# PROBLEM: https://app.codility.com/programmers/lessons/8-leader/equi_leader/
# ANALISYS:
# observations:
# 1) if A[0..s] and A[s+1..N-1] has leaders, then A[0..N-1] has the same leader.
# 2) if leader for A[0..n-1] exist then we need to find A[0..s] and A[s+1..N-1] with the same leader
# 3) ad 2 can be done in linear time as we can maintain number of global leader in both subarraries
# SOLUTION: https://app.codility.com/demo/results/trainingZZ6QWC-HB3/

def dominator(A):
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

def solution(A):
    d_idx = dominator(A)
    if d_idx is -1:
        return 0
    else:
        leader = A[d_idx]
        leader_rc = A.count(leader)
        leader_lc = 0
        eq_leader_count = 0
        N = len(A)
        for s in range(N):
            if A[s] == leader:
                leader_lc += 1
                leader_rc -= 1

            ls = s + 1
            rs = N - ls
            if leader_lc > ls // 2 and leader_rc > rs // 2:
                eq_leader_count += 1
        return eq_leader_count

if __name__ == '__main__':
    print('Start tests..')
    assert solution([1]) == 0
    assert solution([1,1]) == 1
    assert solution([1,2,1]) == 0
    assert solution([1,2,1,1]) == 2
    assert solution([4,3,4,4,4,2]) == 2
    
    print ('passed!')