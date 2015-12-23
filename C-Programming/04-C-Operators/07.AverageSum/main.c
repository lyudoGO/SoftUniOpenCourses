#include <stdio.h>

int main()
{
    int numA, numB, numC;
    float sum;
    printf("Please, enter a three integres separate with space:\n");
    scanf("%d %d %d", &numA, &numB, &numC);

    sum = numA + numB + numC;

    printf("Averege sum: %.3f", sum / 3);
    return 0;
}
