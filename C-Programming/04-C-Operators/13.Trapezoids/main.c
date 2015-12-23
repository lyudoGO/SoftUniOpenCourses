#include <stdio.h>

int main()
{
    float a, b, height, area;
    printf("Please, enter side A, side B and height separate with space:\n");
    scanf("%f %f %f", &a, &b, &height);

    area = ((a + b) / 2) * height;

    printf("Area of trapezoid is: %.2f", area);

    return 0;
}
