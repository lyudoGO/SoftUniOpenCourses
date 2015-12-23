#include <stdio.h>

int main()
{
    long long decimal;
    char hexadecimal[50];
    int i = 1, j;
    printf("Please, enter a decimal number: ");
    scanf("%lld", &decimal);

    while (decimal > 0)
    {
        long long temp = decimal % 16;
        if( temp < 10)
        {
          temp = temp + 48;
        }
        else
        {
         temp = temp + 55;
        }
        hexadecimal[i] = temp;
        i++;
        decimal /= 16;
    }

    for (j = i - 1; j > 0; j--)
    {
        printf("%c", hexadecimal[j]);
    }
    return 0;
}
