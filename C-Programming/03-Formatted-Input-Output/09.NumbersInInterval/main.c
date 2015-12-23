#include <stdio.h>

int main()
{
    int start, end, count = 0, i = 0;
    printf("Please, enter two integer separate with space: ");
    scanf("%d %d", &start, &end);

    for (i = start; i <= end; i++)
    {
        if (i % 5 == 0)
        {
            count++;
        }
    }

    printf("Count: %d", count);
    return 0;
}
