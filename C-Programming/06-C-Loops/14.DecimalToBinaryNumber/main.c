#include <stdio.h>

int main()
{
    long decimal;
    int binary[64], i = 1, j;
    printf("Please, enter a decimal number: ");
    scanf("%ld", &decimal);

    while (decimal > 0)
    {
        binary[i] = decimal % 2;
        i++;
        decimal /= 2;
    }

    for (j = i - 1; j > 0; j--)
    {
        printf("%d", binary[j]);
    }

    return 0;
}
