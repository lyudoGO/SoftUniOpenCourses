#include <stdio.h>

int main()
{
    int numA, numB, greatestDivisor;
    printf("Please, enter integers for a and b: ");
    scanf("%d%d", &numA, &numB);

    greatestDivisor = numA % numB;
    while (greatestDivisor == 0)
    {
        greatestDivisor = numA % greatestDivisor;
    }

    printf("%d", greatestDivisor);

    return 0;
}
