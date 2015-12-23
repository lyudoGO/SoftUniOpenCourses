/* 
 * Write a Boolean expression that returns if the bit at position p 
 * (counting from 0, starting from the right) in given integer number n has 
 * value of 1.
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
    if (bitAtPPosition == 0) 
    {
        printf("%s", "false");
    } 
    else 
    {
        printf("%s", "true");
    }

    return (EXIT_SUCCESS);
}