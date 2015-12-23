/* 
 * Write an expression that extracts from given integer n the value of given 
 * bit at index p.
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
    int bitAtPPosition = (number >> pos) & 1;
    printf("%d", bitAtPPosition);
    return (EXIT_SUCCESS);
}

