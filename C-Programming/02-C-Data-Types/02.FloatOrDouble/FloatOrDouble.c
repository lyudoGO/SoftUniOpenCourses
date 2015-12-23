#include <stdio.h>
#include <stdlib.h>

int main()
{
    float a = 12.345;
    double b = 3456.091;
    double c = 8923.1234857;
    double d = 34.567839023;

    printf("a = %f\nb = %f\n", a, b);
    printf("c = %.7f\nd = %.9f\n", c, d);
    return 0;
}
