#include <stdio.h>

int main()
{
    int number, i;
    printf("Please, enter a integer number: ");
    scanf("%d", &number);

    for (i = 1; i <= number; i++) {
        printf("%d\n", i);
    }

    return 0;
}