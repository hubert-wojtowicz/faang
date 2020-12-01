# A string S consisting of N characters is considered to be properly nested if any of the following conditions is true:

# S is empty;
# S has the form "(U)" or "[U]" or "{U}" where U is a properly nested string;
# S has the form "VW" where V and W are properly nested strings.
# For example, the string "{[()()]}" is properly nested but "([)()]" is not.

# Write a function:

# class Solution { public int solution(String S); }

# that, given a string S consisting of N characters, returns 1 if S is properly nested and 0 otherwise.

# For example, given S = "{[()()]}", the function should return 1 and given S = "([)()]", the function should return 0, as explained above.

# Write an efficient algorithm for the following assumptions:

# N is an integer within the range [0..200,000];
# string S consists only of the following characters: "(", "{", "[", "]", "}" and/or ")".
    
# Solution:
# This is tipical stack problem
# opening bracket push item to stack and closing bracket pop from stack
# closing bracken must fit opening bracket
# time complexity O(N)
# 1 = (
# 2 = [
# 3 = {
# 4 = )
# 5 = ]
# 6 = }
# Solution: https://app.codility.com/demo/results/trainingGKFZDK-39V/

def solution(A):
    S = []
    O = ['(', '[', '{'] # (O)pening
    C = [')', ']', '}'] # (C)losing 
    for b in A:
        if b in O:
            S.append(b)
        else:
            if (len(S) == 0):
                return 0

            o = S.pop()
            if o is O[0] and b is not C[0]:
                return 0
            if o is O[1] and b is not C[1]:
                return 0
            if o is O[2] and b is not C[2]:
                return 0

    return 1 if len(S) == 0 else 0
        
if __name__ == '__main__':
    print ('Start tests..')
    assert solution([]) == 1
    assert solution(['(']) == 0
    assert solution(['[']) == 0
    assert solution(['{']) == 0
    assert solution([')']) == 0
    assert solution([']']) == 0
    assert solution(['}']) == 0
    assert solution(['(',')']) == 1
    assert solution(['[',']']) == 1
    assert solution(['{','}']) == 1
    assert solution(['(',')']) == 1
    assert solution(['[',']']) == 1
    assert solution(['{','}']) == 1
    assert solution(['(','[','{','}',']',')']) == 1
    assert solution(['(','[',')','(',')',']']) == 0
    assert solution(['{','[','(',')','(',')',']','}']) == 1
    assert solution(['{','[','(',')','(',')',']','}','{','[','(',')','(',')',']','}']) == 1
    print ('passed!')