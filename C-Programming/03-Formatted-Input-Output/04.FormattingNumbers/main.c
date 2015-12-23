#include <stdio.h>
#include <string.h>
#define TEXT_FORMAT "|%-10X|%10s|%10.2f|%-10.3f|\n"

char *printBinary (int n, char * string);

int main()
{
    int numA;
    double numB, numC;

    printf("Please, enter a integer number a (0..500): ");
    scanf("%d", &numA);
    printf("Please, enter a float-point number b: ");
    scanf("%lf", &numB);
    printf("Please, enter a float-point number c: ");
    scanf("%lf", &numC);

    char *binaryNum[11];
    printf(TEXT_FORMAT, numA, printBinary(numA, binaryNum), numB, numC);
    return 0;
}

char *printBinary (int n, char * string)
{
    int i;
    for (i = 1 << 9; i > 0; i = i / 2)
    {
      (n & i) ? strcat(string, "1"): strcat(string, "0");
    }
    return string;
}
