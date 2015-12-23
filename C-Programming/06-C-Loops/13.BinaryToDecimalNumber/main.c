#include <stdio.h>
#include <string.h>

int main()
{
    char binary[64];
    long decimal = 0;
    int power = 1, i;
    printf("Please, enter a binary number: ");
    scanf("%s", binary);
    int lenght = strlen(binary);

    for (i = lenght - 1; i >= 0; i--)
    {
        int num = binary[i] - '0';
        decimal += num * power;
        power *= 2;
    }

    printf("%ld", decimal);
    return 0;
}
