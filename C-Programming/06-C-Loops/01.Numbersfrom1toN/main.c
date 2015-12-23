#include <stdio.h>

int main()
{
    int num, i;
    printf("Please, enter a integer: ");
    scanf("%d", &num);
    for (i = 1; i <= num; i++)
    {
        printf("%d ", i);
    }

    return 0;
}
