/* 
 * Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of 
 * given 32-bit unsigned integer.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    unsigned int number;
    printf("Please, enter a unsigned integer: ");
    scanf("%u", &number);
    
    int bitAt3Position = (number >> 3) & 1;
    int bitAt4Position = (number >> 4) & 1;
    int bitAt5Position = (number >> 5) & 1;
    int bitAt24Position = (number >> 24) & 1;
    int bitAt25Position = (number >> 25) & 1;
    int bitAt26Position = (number >> 26) & 1;
    
    number = number & ~(1 << 3);
    number = number | (bitAt24Position << 3);
    number = number & ~(1 << 4);
    number = number | (bitAt25Position << 4);
    number = number & ~(1 << 5);
    number = number | (bitAt26Position << 5);
    number = number & ~(1 << 24);
    number = number | (bitAt3Position << 24);
    number = number & ~(1 << 25);
    number = number | (bitAt4Position << 25);
    number = number & ~(1 << 26);
    number = number | (bitAt5Position << 26);
    printf("%u", number);
    
    return (EXIT_SUCCESS);
}