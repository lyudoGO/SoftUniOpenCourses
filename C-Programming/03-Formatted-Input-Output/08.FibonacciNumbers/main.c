#include <stdio.h>

int main()
{
    int number, i;
    printf("Please, enter a integer N: ");
    scanf("%d", &number);

    long long f0 = 0;
    long long f1 = 1;
    if (number == 1)
    {
        printf("%lld ", f0);
    }
    else if (number == 2)
    {
        printf("%lld %lld", f0, f1);
    }
    else
    {
        printf("%lld %lld", f0, f1);
        for (i = 2; i < number; i++)
        {
            long long newFib = f0 + f1;
            printf(" %lld", newFib);
            f0 = f1;
            f1 = newFib;
         }
    }

    return 0;
}
