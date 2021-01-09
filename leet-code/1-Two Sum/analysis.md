- Assume length of array is N.
- Assume expected sum is equal to S.
- Assume absolute sum of any two numbers is less than int32 size i.e. sum is between (-2,147,483,648 to 2,147,483,647). Th
- Assume 0,1 or many solutions possible

Brute forcr O(N*(N-1)/2)=O(N^2) rely on iterating every element and seeking another element of array sitting upfront that sum to S.

There exist solution with usign hash map.
Whose complexity is O(N*lg2(N))

Steps

1. Read table A=[A1,A2,...AN] 
2. Find minimal element of m = Min(B)
3. Normalize table C=[A1-m, A2-m,...,AN-m], now table c contains only positive values
4. Create hash map D[2,147,483,647 * 2 + 1] in such way: 512MB
    D[2,147,483,647 * 2 + 1] <- 0
    for i...N:
       ++D[C[i]];
5. Loop through A[]
    for i..N:
        if(S == A[i] + D[A[i]-S-m]*(A[i]-S))
        {
            if(2*A[i] == S)
            {
                if(D[A[i]-S-m]>1)
                {
                    // solution with index i exist
                    // can find j index in O(n) time
                }
                else
                {
                    //no solution
                }
            }
            else
            {
                // solution with index i exist
                // can find j index in O(n) time
            }
        }

TOTAL O(n*lg2 n)