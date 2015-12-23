#include <stdio.h>

int main()
{
    int num, i;
    printf("Please, enter a positive integer: ");
    scanf("%d", &num);
    for (i = 1; i <= num; i++)
    {
        if (i % 3 != 0 && i % 7 != 0)
        {
            printf("%d ", i);
        }
    }

    return 0;
}
