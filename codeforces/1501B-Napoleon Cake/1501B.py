# https://codeforces.com/problemset/problem/1501/B
# https://codeforces.com/problemset/submission/1501/118841862
 
if __name__ == '__main__':
    t = int(input())
    while t>0:
        t-=1
        n = int(input())
        A = list(map(int, input().split(' ')))
        ccd=0 # current creem depth
        for n in range(n-1, -1, -1):
            ccd = max(ccd-1, A[n])
            A[n]=(1 if ccd>0 else 0)

        print(' '.join(str(x) for x in A))
