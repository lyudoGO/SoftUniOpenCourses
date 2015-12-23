/* 
 * We are given an integer number n, a bit value v (v=0 or 1) and a position p.
 * Write a sequence of operators (a few lines of C code) that modifies n to 
 * hold the value v at the position p from the binary representation of n while 
 * preserving all other bits in n.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int number, pos, value;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    printf("Please, enter a position: ");
    scanf("%d", &pos);
    printf("Please, enter a bit value: ");
    scanf("%d", &value);
    int mask = (1 << pos);
    if (value == 1) 
    {
        number = number | mask;
    }
    else
    {
        number = number & ~mask;
    }
    printf("%d", number);
    
    return (EXIT_SUCCESS);
}