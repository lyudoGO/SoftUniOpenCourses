#include <stdio.h>
#include <limits.h>

int main()
{
    int num, i;
    int min = 0, max = 0, sum = 0;
    scanf("%d", &num);

    for (i = 0; i < num; i++)
    {
        int input;
        scanf("%d", &input);
        if (input > max)
        {
            max = input;
        }
        if (input < max)
        {
            min = input;
        }
        sum += input;
    }

    double average = (double)sum / num;
    printf("min = %.2f\nmax = %.2f\n", (double)min, (double)max);
    printf("sum = %.2f\navg = %.2f\n", (double)sum, average);

    return 0;
}
