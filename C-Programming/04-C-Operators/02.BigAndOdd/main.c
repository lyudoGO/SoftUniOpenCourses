#include <stdio.h>

int main()
{
    int num = 0;
    printf("Please, enter a integer number: ");
    scanf("%d", &num);

    if (num % 2 != 0 && num > 20)
    {
        printf("%d", 1);
    }
    else
    {
        printf("%d", 0);
    }

    return 0;
}
