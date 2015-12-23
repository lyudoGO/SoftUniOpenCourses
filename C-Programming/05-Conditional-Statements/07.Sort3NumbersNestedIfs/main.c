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

    if(numA >= numB && numA >= numC)
    {
        if (numB >= numC)
        {
            printf("%.2f %.2f %.2f", numA, numB, numC);
        }
        else
        {
            printf("%.2f %.2f %.2f", numA, numC, numB);
        }
    }
    else if (numB >= numA && numB >= numC)
    {
        if (numA >= numC)
        {
            printf("%.2f %.2f %.2f", numB, numA, numC);
        }
        else
        {
            printf("%.2f %.2f %.2f", numB, numC, numA);
        }
    }
    else if(numC >= numA && numC >= numB)
    {
        if (numA >= numB)
        {
            printf("%.2f %.2f %.2f", numC, numA, numB);
        }
        else
        {
            printf("%.2f %.2f %.2f", numC, numB, numA);
        }
    }

    return 0;
}
