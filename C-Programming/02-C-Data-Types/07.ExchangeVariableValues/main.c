#include <stdio.h>

int main()
{
    int a = 5;
    int b = 10;

    printf("Before:\na = %d\nb = %d\n", a, b);

    a = a ^ b;
    b = a ^ b;
    a = b ^ a;
    printf("After:\na = %d\nb = %d\n", a, b);
    return 0;
}
