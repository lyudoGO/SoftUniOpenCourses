#include <stdio.h>
#include <math.h>

int main()
{
    double numberA, numberB;
    double eps = 0.000001;

    printf("Please, enter a float number a: ");
    scanf("%f", &numberA);
    printf("Please, enter a float number b: ");
    scanf("%f", &numberB);

    double diff = abs(numberA - numberB);
    if ( diff < eps) {
       printf("true\n");
    }
    else {
        printf("false\n");
    }

    return 0;
}
