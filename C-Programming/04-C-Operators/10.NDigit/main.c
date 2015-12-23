#include <stdio.h>

int main()
{
    int n, number;
    printf("Please, enter a integer number for n: ");
    scanf("%d", &n);
    printf("Please, enter a integer number: ");
    scanf("%d", &number);

    n--;
    while (n > 0)
    {
        number = number / 10;
        n--;
    }

    if (number)
    {
        printf("%d", number % 10);
    }
    else
    {
        printf("%c", '-');
    }

    return 0;
}
