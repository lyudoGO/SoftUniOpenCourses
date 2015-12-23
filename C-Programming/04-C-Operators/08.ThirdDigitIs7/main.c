#include <stdio.h>

int main()
{
    int num = 0;
    printf("Please, enter a integer number: ");
    scanf("%d", &num);
    if ((num / 100) % 10 == 7)
    {
        printf("%s", "true");
    }
    else
    {
        printf("%s", "false");
    }

    return 0;
}
