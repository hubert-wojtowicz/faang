# https://codeforces.com/problemset/problem/466/A
#
# a - cost of ticket for 1 ride
# b - cost of ticket for m rides
# n - number of times ann must use subway
# 
# 1 <= n, m, a, b <= 1000
# 
# Analisys:
# Ann needs to ride n times. She needs to DECIDE what set of tickets is the chapest to satisfy her travel needs.
# This is decision making problem then. To solve her problem we needs GOAL and ARGUMENTS while making decision.
# GOAL: minimum of value k*a + j*b - amount she spent (k,j number of tickets bought), while n >= k + j*m
# ARGUMENTS: she has only two possibilities buy single ride or multiple ride ticket.
# Lets introduce cosr per one ride. For single ride ticket it is allways 'a', for multiride 'b/m'
#
# If 'a' <= 'b/m' there is no point of buying multiride ticket. She will spent a*n.
# Otherwise when 'a' > 'b/m', she will start buying multiride ticket. But there still is edge case when j*m multiride tickets can exceed number of rides Ann assume to do. Let's devide:
# floor(n/m)*b + (n - floor(n/m)*m)*a      - she has precise no. ride she need
# (floor(n/m)+1)*b                      - she has more av. ride than required

def solution(n, m, a, b):
    if a <= (b/m):
        return n*a
    else: 
        floor = n//m
        only_multiride_tickets_price =(floor+1)*b
        hibrid_tickets_price = floor*b + (n-floor*m)*a
        if only_multiride_tickets_price < hibrid_tickets_price:
            return only_multiride_tickets_price
        else:
            return hibrid_tickets_price

        
is_test = False        
if __name__ == '__main__':
    if is_test:
        print ('Start tests..')
        assert solution(1, 1, 1, 1) == 1
        assert solution(2, 1, 1, 1) == 2
        assert solution(2, 2, 2, 1) == 1
        assert solution(3, 2, 2, 1) == 2
        assert solution(6, 2, 1, 2) == 6
        assert solution(5, 2, 2, 3) == 8
        print ('passed!')

    (n, m, a, b) = map(int, input().split())
    print(solution(n, m, a, b))
