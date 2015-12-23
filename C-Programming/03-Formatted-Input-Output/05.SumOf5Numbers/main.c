#include <stdio.h>

int main()
{
    double numA, numB, numC, numD, numE, sum;
    printf("Please, enter 5 numbers separate with space:\n");
    scanf("%lf%lf%lf%lf%lf", &numA, &numB, &numC, &numD, &numE);

    sum = numA + numB + numC + numD + numE;
    printf("Sum is: %.2f", sum);

    return 0;
}
