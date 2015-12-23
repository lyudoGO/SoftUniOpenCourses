#include <stdio.h>

int main()
{
    int userChoose, number;
    float numberD;
    char string[1000];
    printf("%s", "Please choose a type: \n");
    printf("%s", "1 --> int \n");
    printf("%s", "2 --> double \n");
    printf("%s", "3 --> string \n");

    int machtes = scanf("%d", &userChoose);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    switch (userChoose)
    {
        case 1:
            printf("Please enter a int: ");
            scanf("%d", &number);
            printf("%d", ++number);
            break;
        case 2:
            printf("Please enter a double: ");
            scanf("%f", &numberD);
            printf("%.3f", ++numberD);
            break;
        case 3:
            printf("Please enter a string: ");
            scanf("%s", string);
            printf("%s%c", string, '*');
            break;
        default:
            printf("Wrong choice!");
            break;
    }
    return 0;
}
