#include <stdio.h>

int main()
{
    float numA, numB, numC, product;
    printf("Please, enter three numbers separate with space: ");
    int machtes = scanf("%f%f%f", &numA, &numB, &numC);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    product = numA * numB * numC;
    if (product < 0)
    {
        printf("%c", '-');
    }
    else if (product > 0)
    {
        printf("%c", '+');
    }
    else
    {
        printf("%c", '0');
    }
    return 0;
}
