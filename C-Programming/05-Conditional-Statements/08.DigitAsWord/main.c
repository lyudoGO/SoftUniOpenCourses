#include <stdio.h>

int main()
{
    int num;
    printf("Please, enter a numbers in range [0..9]: ");
    int machtes = scanf("%d", &num);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    switch (num)
    {
        case 0: printf("%s", "zero"); break;
        case 1: printf("%s", "one"); break;
        case 2: printf("%s", "two"); break;
        case 3: printf("%s", "three"); break;
        case 4: printf("%s", "four"); break;
        case 5: printf("%s", "five"); break;
        case 6: printf("%s", "six"); break;
        case 7: printf("%s", "seven"); break;
        case 8: printf("%s", "eight"); break;
        case 9: printf("%s", "nine"); break;
        default: printf("%s", "not a digit"); break;
    }

    return 0;
}
