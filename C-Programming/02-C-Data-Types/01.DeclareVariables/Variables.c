#include <stdio.h>
#include <stdlib.h>

int main()
{
    short a = -10000;
    char b = 97;
    char c = 115;
    unsigned short d = 52130;
    unsigned int e = 4825932;
    double f = 8942492113;
    double g = -35982859328592389;

    printf("a = %d\nb = %d\nc = %d\n", a, b, c);
    printf("d = %d\ne = %d\nf = %.f\ng = %.f", d, e, f, g);
    return 0;
}
