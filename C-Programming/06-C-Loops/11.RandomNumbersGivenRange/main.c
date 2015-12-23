#include <stdio.h>

int main()
{
    int i, num, min, max, random;
    printf("Please, enter integers N, min, max separate with space: ");
    scanf("%d%d%d", &num, &min, &max);
    random = (max + 1 - min) + min;

    for (i = 0; i < num; i++)
    {
        printf("%d ", rand() % random);
    }

    return 0;
}
