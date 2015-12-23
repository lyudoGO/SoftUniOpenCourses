#include <stdio.h>

int main()
{
    double radius, area, perimeter;
    printf("Please, enter a radius: ");
    scanf("%lf", &radius);

    area = 2 * 3.1415 * radius;
    perimeter = 3.1415 * radius * radius;

    printf("Area: %.2f\n", area);
    printf("Perimeter: %.2f", perimeter);

    return 0;
}
