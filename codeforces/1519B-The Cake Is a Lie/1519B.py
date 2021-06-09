# https://codeforces.com/problemset/problem/1519/B
# https://codeforces.com/problemset/submission/1519/118914154

if __name__ == '__main__':
    t = int(input())
    while t>0:
        t-=1
        (n,m,k) = map(int, input().split(' '))
        print("YES" if m-1+(n-1)*m==k else "NO")