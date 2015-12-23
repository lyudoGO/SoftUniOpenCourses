#include <stdio.h>

int main()
{
    float numA, numB, numC, numD, numE;
    printf("Please, enter five numbers separate with space: ");
    int machtes = scanf("%f%f%f%f%f", &numA, &numB, &numC, &numD, &numE);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    float biggestNumber = 0;
    if (numA > numB)
    {
        biggestNumber = numA;
    }
    else
    {
        biggestNumber = numB;
    }
    if (numC > biggestNumber)
    {
        biggestNumber = numC;
    }
    if (numD > biggestNumber)
    {
        biggestNumber = numD;
    }
    if (numE > biggestNumber)
    {
        biggestNumber = numE;
    }

    printf("%.2f", biggestNumber);
    return 0;
}
