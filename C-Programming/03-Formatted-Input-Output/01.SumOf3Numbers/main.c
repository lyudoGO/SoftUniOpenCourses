#include <stdio.h>

int main()
{
    double numberA, numberB, numberC, sum;
    printf("Please, enter a real number a: ");
    scanf("%lf", &numberA);
    printf("Please, enter a real number b: ");
    scanf("%lf", &numberB);
    printf("Please, enter a real number c: ");
    scanf("%lf", &numberC);

    sum = numberA + numberB + numberC;
    printf("Sum is: %.2f", sum);

    return 0;
}
