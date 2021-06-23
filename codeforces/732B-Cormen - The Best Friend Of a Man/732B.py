# https://codeforces.com/problemset/problem/732/B

def solution(n, k, a):
    b=[]
    # ambiguity of task - left commented code just to call it out
    # if n==1:
    #     toAdd = max(0, k-a[0])
    #     b.append(a[0]+toAdd)
    #     return (toAdd, b)
    allAdded=0
    b.append(a[0])
    for i in range(1,n):
        toAdd = max(0, k-(b[-1]+a[i]))
        b.append(a[i]+toAdd)
        allAdded += toAdd

    return (allAdded, b)

is_test = False
if __name__ == '__main__':
    if is_test:
        print ('Start tests..')
        assert solution(1, 10, [1]) == (0, [1])
        #assert solution(1, 2, [1]) == (1, [2])
        assert solution(2, 3, [1,1]) == (1, [1,2])
        assert solution(3, 5, [2,0,1]) == (4, [2,3,2])
        assert solution(3, 1, [0,0,0]) == (1, [0,1,0])
        assert solution(4, 6, [2,4,3,5]) == (0, [2,4,3,5])
        print ('passed!')

    (n,k) = map(int, input().split(' '))
    a=list(map(int, input().split(' ')))
    (added, b)=solution(n,k,a)
    print(added)
    print(' '.join(str(x) for x in b))
