#include <stdio.h>

int main()
{
    int numberN, i;
    double sum, tempNum;
    printf("Please, enter integer for N: ");
    scanf("%d", &numberN);

    for (i = 1; i <= numberN; i++) {
        printf("Enter %d number: ", i);
        scanf("%lf", &tempNum);
        sum += tempNum;
    }

    printf("Sum is: %.2f", sum);
    return 0;
}
