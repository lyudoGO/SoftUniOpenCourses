#include <stdio.h>

int main()
{
    float width, height, perimeter, area;
    printf("Please, enter a width and height separate with space:\n");
    scanf("%f %f", &width, &height);

    perimeter = 2 * width + 2 * height;
    area = width * height;

    printf("Perimeter: %.3f\n", perimeter);
    printf("Area: %.3f\n", area);

    return 0;
}
