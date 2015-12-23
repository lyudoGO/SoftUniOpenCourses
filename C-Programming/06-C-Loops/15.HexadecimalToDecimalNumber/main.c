#include <stdio.h>

int main()
{
    char hexadecimal[30];
    long long decimal = 0, i, tmp;
    long long power = 1;
    printf("Please, enter a hexadecimal number: ");
    scanf("%s", hexadecimal);
    int lenght = strlen(hexadecimal);

    for (i = lenght - 1; i >= 0; i--)
    {
//        switch (hexadecimal[i])
//        {
//            case 'A':tmp = 10;break;
//            case 'B':tmp = 11;break;
//            case 'C':tmp = 12;break;
//            case 'D':tmp = 13;break;
//            case 'E':tmp = 14;break;
//            case 'F':tmp = 15;break;
//            default: tmp = hexadecimal[i] - '0';break;
//        }
        if (hexadecimal[i] > '9')
        {
            decimal += (hexadecimal[i] - 55) * power;
        }
        else
        {
            decimal += (hexadecimal[i] - '0') * power;
        }
        //decimal += tmp * power;
        power *= 16;
    }

    printf("%lld", decimal);

    return 0;
}
