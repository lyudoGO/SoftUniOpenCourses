#include <stdio.h>

int main()
{
    float numA, numB;
    printf("Please, enter two numbers: ");
    int machtes = scanf("%f%f", &numA, &numB);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    if (numA > numB)
    {
        float tempNum = numA;
        numA = numB;
        numB = tempNum;
    }

    printf("%.2f %.2f", numA, numB);
    return 0;
}
