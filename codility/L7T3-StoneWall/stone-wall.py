# PROBLEM:
# Minimal rectangular division of comb-like structure where comb tooth described by array of number.
# N[1..100,000] is number of combs
# H[i] where 0<=i<N is size of particular tooth counted from left to right and within range [1..1,000,000,000]
#
# ANALISYS:
# 1) I noticed that division is caused by height change
# 2) Order of change is important 
# 3) when we will do right-side projection to prependicular plane we can notice local rule:
#   - if previous wall was equal to current there will be no new rectangular division required
#   - if previous wall was smaller than current this will be cutted by smaller but for now we keep it on stack
#   - if previous wass was bigger than current then we count this as new division but we notice also:
#        wals H = [4,3,4,2,4] for change from 4 to 2 will cause 2 division as wall from heigh 4 to 2 will be devided twice by 2nd element adn by bottom line
# we can track such situation with maintaining stack.
# solution here is O(N) what for sure satifies here input size to perform in reasonable time
# SOLUTION: https://app.codility.com/demo/results/training4JTU8J-A7G/
def solution(H):
    count = 0
    S = [H[0]]
    for i in range(1, len(H)):
        if S[-1] == H[i]:
            continue
        elif S[-1] < H[i]:
            S.append(H[i])
        else:
            while S and S[-1] > H[i]:
                count += 1
                S.pop()

            if not S or (S and S[-1] != H[i]):
                S.append(H[i])

    return count + len(S)

if __name__ == '__main__':
    print ('Start tests..')
    assert solution([1]) == 1
    assert solution([1,2]) == 2
    assert solution([2,1]) == 2
    assert solution([1,1,1]) == 1
    assert solution([1,2,3]) == 3
    assert solution([3,2,1]) == 3
    assert solution([8,8,5,7,9,8,7,4,8]) == 7
    assert solution([8,8,6,9,5,8,4,9]) == 7
    print ('passed!')