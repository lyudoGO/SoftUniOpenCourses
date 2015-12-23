#include <stdio.h>

int main()
{
    int number;
    printf("Please, enter a number in range [0...999]: ");
    int machtes = scanf("%d", &number);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    if (number <= 999 && number >= 0)
    {
        switch (number / 100)
        {
            case 0: break;
            case 1: printf("One hundred "); break;
            case 2: printf("Two hundred "); break;
            case 3: printf("Three hundred "); break;
            case 4: printf("Four hundred "); break;
            case 5: printf("Five hundred "); break;
            case 6: printf("Six hundred "); break;
            case 7: printf("Seven hundred "); break;
            case 8: printf("Eight hundred "); break;
            case 9: printf("Nine hundred "); break;
            default: break;
        }

        if (number / 100 != 0 && number % 100 != 0)
        {
            printf("and ");
        }

        switch (number / 10 % 10)
        {
            case 0: break;
            case 1:
                switch ((number % 100) % 10)
                {
                    case 0: printf("Ten "); break;
                    case 1: printf("Eleven "); break;
                    case 2: printf("Tuelve "); break;
                    case 3: printf("Thirteen "); break;
                    case 4: printf("Fourteen "); break;
                    case 5: printf("Fivteen "); break;
                    case 6: printf("Sixteen "); break;
                    case 7: printf("Seventeen "); break;
                    case 8: printf("Eighteen "); break;
                    case 9: printf("Nineteen "); break;
                    default: break;
                }
                break;
            case 2: printf("Twenty "); break;
            case 3: printf("Thirty "); break;
            case 4: printf("Fourty "); break;
            case 5: printf("Fivty "); break;
            case 6: printf("Sixty "); break;
            case 7: printf("Seventy "); break;
            case 8: printf("Eighty "); break;
            case 9: printf("Ninety "); break;
        }

        switch (number % 10)
        {
            case 0: if (number == 0) { printf("Zero"); } break;
            case 1: if (number / 10 % 10 == 1) break; printf("One"); break;
            case 2: if (number / 10 % 10 == 1) break; printf("Two"); break;
            case 3: if (number / 10 % 10 == 1) break; printf("Three"); break;
            case 4: if (number / 10 % 10 == 1) break; printf("Four"); break;
            case 5: if (number / 10 % 10 == 1) break; printf("Five"); break;
            case 6: if (number / 10 % 10 == 1) break; printf("Six"); break;
            case 7: if (number / 10 % 10 == 1) break; printf("Seven"); break;
            case 8: if (number / 10 % 10 == 1) break; printf("Eight"); break;
            case 9: if (number / 10 % 10 == 1) break; printf("Nine"); break;
            default: break;
        }
    }
    else
    {
        printf("Out of range!");
    }

    return 0;
}
