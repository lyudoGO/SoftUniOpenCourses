#include <stdio.h>

int main()
{
    int number1, number2, number3, number4, number5, flag = 0;
    int numbers[5];
    printf("Please, enter five integer separate with space: ");
    int machtes = scanf("%d%d%d%d%d", &number1, &number2, &number3, &number4, &number5);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }
    numbers[0] = number1;
    numbers[1] = number2;
    numbers[2] = number3;
    numbers[3] = number4;
    numbers[4] = number5;

    int n1, n2, n3, n4, n5;
    for (n1 = 0; n1 < 5; n1++)
    {
        for (n2 = n1 + 1; n2 < 5; n2++)
        {
            for (n3 = n2 + 1; n3 < 5; n3++)
            {
                for (n4 = n3 + 1; n4 < 5; n4++)
                {
                    for (n5 = n4 + 1; n5 < 5; n5++)
                    {
                        if (numbers[n1] + numbers[n2] + numbers[n3] + numbers[n4] + numbers[n5] == 0)
                        {
                            flag = 1;
                            printf("%d + %d + %d + %d + %d = 0\n", numbers[n1], numbers[n2], numbers[n3], numbers[n4], numbers[n5]);
                        }
                    }
                    if (numbers[n1] + numbers[n2] + numbers[n3] + numbers[n4] == 0)
                    {
                        flag = 1;
                        printf("%d + %d + %d + %d = 0\n", numbers[n1], numbers[n2], numbers[n3], numbers[n4]);
                    }
                }
                if (numbers[n1] + numbers[n2] + numbers[n3] == 0)
                {
                    flag = 1;
                    printf("%d + %d + %d = 0\n", numbers[n1], numbers[n2], numbers[n3]);
                }
            }
            if (numbers[n1] + numbers[n2] == 0)
            {
                flag = 1;
                printf("%d + %d = 0\n", numbers[n1], numbers[n2]);
            }

        }
        if (numbers[n1] == 0)
        {
            flag = 1;
            printf("%d = 0\n", numbers[n1]);
        }

    }

    if (!flag)
    {
        printf("no zero subset");
    }

    return 0;
}
