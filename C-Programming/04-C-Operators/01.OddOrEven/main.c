#include <stdio.h>

int main()
{
    int num = 0;
    printf("Please, enter a integer number: ");
    scanf("%d", &num);

    if (num % 2 == 0)
    {
        printf("%d", 0);
    }
    else
    {
        printf("%d", 1);
    }

    return 0;
}
