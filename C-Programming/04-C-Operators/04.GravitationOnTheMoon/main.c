#include <stdio.h>

int main()
{
    float weight = 0;
    printf("Please, enter weight of man: ");
    scanf("%f", &weight);

    printf("%.3f", weight * 0.17);

    return 0;
}
