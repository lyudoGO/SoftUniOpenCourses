#include <stdio.h>
#include <math.h>

int main()
{
    float x, y;
    printf("Please, enter X and Y separate with space: ");
    scanf("%f %f", &x, &y);

    float d = sqrt(pow((x - 1), 2) + pow((y - 1), 2));

    if (d <= 1.5 && y > 1)
    {
        printf("%s", "Yes");
    }
    else
    {
        printf("%s", "No");
    }

    return 0;
}
