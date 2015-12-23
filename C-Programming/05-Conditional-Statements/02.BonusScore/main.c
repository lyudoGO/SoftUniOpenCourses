#include <stdio.h>

int main()
{
    int num;
    printf("Please, enter a numbers in range [1..9]: ");
    int machtes = scanf("%d", &num);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    switch (num)
    {
        case 1:
        case 2:
        case 3:
            printf("%d", num * 10);
            break;
        case 4:
        case 5:
        case 6:
            printf("%d", num * 100);
            break;
        case 7:
        case 8:
        case 9:
            printf("%d", num * 1000);
            break;
        default:
            printf("%s", "invalid score");
            break;
    }

    return 0;
}
