#include <stdio.h>

int main()
{
    int num, count = 0;;
    unsigned long long nFactorial = 1, i;
    printf("Please, enter a integer: ");
    scanf("%d", &num);

    for (i = 1; i <= num; i++)
    {
        nFactorial *= i;
        while (nFactorial % 10 == 0)
        {
            count++;
            nFactorial /= 10;
        }
    }

    printf("%d", count);

    return 0;
}
