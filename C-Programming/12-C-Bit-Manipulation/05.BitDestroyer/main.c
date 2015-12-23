/* 
 * Write a program that sets the bit at position p to 0. Print the resulting number.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int number, pos;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    printf("Please, enter a position: ");
    scanf("%d", &pos);
    int mask = ~(1 << pos);
    int result = number & mask;
    printf("%d", result);
    
    return (EXIT_SUCCESS);
}

