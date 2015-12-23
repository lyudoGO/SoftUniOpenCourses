#include <stdio.h>

int main()
{
    int num = 0;
    int digA, digB, digC, digD;
    printf("Please, enter a integer number: ");
    scanf("%d", &num);

    digA = num / 1000;
    digB = (num / 100) % 10;
    digC = (num / 10) % 10;
    digD = num % 10;
    int sum = digA + digB + digC + digD;
    int reversed = digD * 1000 + digC * 100 + digB * 10 + digA;
    int lastDig = digD * 1000 + (num / 10);
    int exchanged = digA * 1000 + digC * 100 + digB * 10 + digD;

    printf("Sum = %d\nReversed = %d\n", sum, reversed);
    printf("Last digit in front = %d\nDigit exchanged = %d", lastDig, exchanged);
    return 0;
}
