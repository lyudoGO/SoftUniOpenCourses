#include <stdio.h>
#include <math.h>

int main()
{
    float x, y;
    printf("Please, enter X and Y separate with space: ");
    scanf("%f %f", &x, &y);

    float d = sqrt((x * x) + (y * y));
    if (d <= 2)
    {
        printf("%s", "Yes");
    }
    else
    {
        printf("%s", "No");
    }

    return 0;
}
