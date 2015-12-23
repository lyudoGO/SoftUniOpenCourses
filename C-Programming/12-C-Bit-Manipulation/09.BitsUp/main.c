/* 
 * This problem is from Variant 2 of C# Basics exam from 10-04-2014 Evening.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int n, step, bytes;
    int i, bit, index = 0;
    scanf("%d", &n);
    scanf("%d", &step);

    for (i = 0; i < n; i++) 
    {
        scanf("%d", &bytes);
        for (bit = 7; bit >= 0; bit--) 
        {
            if ((index % step == 1) || (step == 1 && index > 0)) 
            {
                bytes = bytes | (1 << bit);
            }
            index++;
        }
        printf("%d\n", bytes);
    }

    return (EXIT_SUCCESS);
}