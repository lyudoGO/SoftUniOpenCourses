#include <stdio.h>

int main()
{
    unsigned long long numN, numK, i;
    unsigned long long nOverKFactorial = 1, nMinusKFactorial = 1;
    printf("Enter a integer for N: ");
    scanf("%lld", &numN);
    printf("Enter a integer for K: ");
    scanf("%lld", &numK);

    for (i = numN; i > numK; i--)
    {
        nOverKFactorial = nOverKFactorial * i;
    }

    for (i = 1; i <= numN - numK; i++)
    {
        nMinusKFactorial = nMinusKFactorial * i;
    }

    printf("%lld", nOverKFactorial / nMinusKFactorial);

    return 0;
}
