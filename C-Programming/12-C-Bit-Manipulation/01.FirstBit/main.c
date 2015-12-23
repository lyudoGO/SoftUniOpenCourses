/* 
 * Write a program that prints the bit at position 1 of a number.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int number;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    int bitAt1Position = (number >> 1) & 1;
    printf("%d", bitAt1Position);
    
    return (EXIT_SUCCESS);
}

