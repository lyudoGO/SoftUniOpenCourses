#include <stdio.h>

int main()
{
    int num = 0;
    printf("Please, enter a integer number: ");
    scanf("%d", &num);

    if (num % 9 == 0 || num % 11 == 0 || num % 13 == 0)
    {
        printf("%d", 1);
    }
    else
    {
        printf("%d", 0);
    }

    return 0;
}
