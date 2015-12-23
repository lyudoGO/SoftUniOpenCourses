/* 
 * This problem is from Variant 3 of C# Basics exam from 11-04-2014 Morning
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    unsigned long long number, sieves;
    int count, result = 0;
    scanf("%llu", &number);
    scanf("%d", &count);
    int i;
    for (i = 0; i < count; i++) 
    {
        scanf("%llu", &sieves);
        number = number & ~(sieves);
    }

    for (i = 0; i < 64; i++) 
    {
        unsigned long long firstBit = number & 1;
        if (firstBit == 1) 
        {
            result++;
        }
        number = number >> 1;
    }

    printf("%d", result);
    return (EXIT_SUCCESS);
}