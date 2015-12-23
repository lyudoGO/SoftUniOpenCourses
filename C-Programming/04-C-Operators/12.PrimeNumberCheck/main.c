#include <stdio.h>
#include <math.h>

int main()
{
    int num, i, isPrime = 1;
    printf("Please, enter a integer number <= 100: ");
    scanf("%d", &num);

    if (num <= 1)
    {
        isPrime = 0;
    }
    else
    {
        for (i = 2; i <= sqrt(num); i++)
        {
            if (num % i == 0)
            {
                isPrime = 0;
                break;
            }
        }
    }

    printf("%s", isPrime ? "true" : "false");
    return 0;
}
