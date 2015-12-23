#include <stdio.h>

int main()
{
    float numA, numB, numC;
    printf("Please, enter three numbers separate with space: ");
    int machtes = scanf("%f%f%f", &numA, &numB, &numC);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    if (numA > numB && numA > numC)
    {
        printf("%.2f", numA);
    }
    else if (numB > numA && numB > numC)
    {
        printf("%.2f", numB);
    }
    else
    {
        printf("%.2f", numC);
    }

    return 0;
}
