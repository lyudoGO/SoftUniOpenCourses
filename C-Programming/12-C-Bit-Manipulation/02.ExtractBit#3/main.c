/* 
 * Using bitwise operators, write an expression for finding the value of the 
 * bit #3 of a given unsigned integer. The bits are counted from right to left,
 * starting from bit #0. The result of the expression should be either 1 or 0.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    unsigned int number;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    unsigned int bitAt3Position = (number >> 3) & 1;
    printf("%d", bitAt3Position);
    return (EXIT_SUCCESS);
}

