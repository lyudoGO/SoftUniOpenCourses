#include <stdio.h>

int main()
{
    int numN, numX, i;
    double sum = 1, nFactorial = 1, xPower = 1;
    printf("Enter a integer for N: ");
    scanf("%d", &numN);
    printf("Enter a integer for X: ");
    scanf("%d", &numX);

    for (i = 1; i <= numN; i++)
    {
        xPower = xPower * numX;
        nFactorial = nFactorial * i;
        sum = sum + nFactorial / xPower;
    }
    printf("%.5f", sum);

    return 0;
}
