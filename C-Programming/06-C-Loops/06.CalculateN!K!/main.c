#include <stdio.h>

int main()
{
    unsigned long long numN, numK, i;
    unsigned long long nFactorial = 1;
    printf("Enter a integer for N: ");
    scanf("%lld", &numN);
    printf("Enter a integer for K: ");
    scanf("%lld", &numK);

    for (i = numN; i > numK; i--)
    {
        nFactorial = nFactorial * i;
    }
    printf("%lld", nFactorial);

    return 0;
}
