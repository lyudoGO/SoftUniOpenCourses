/* 
 * Write a program that exchanges bits {p, p+1, …, p+k-1} with bits 
 * {q, q+1, …, q+k-1} of a given 32-bit unsigned integer. 
 * The first and the second sequence of bits may not overlap.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    unsigned int number, posP, posQ, numK;
    printf("Please, enter a integer: ");
    scanf("%u", &number);
    printf("Please, enter a position P: ");
    scanf("%d", &posP);
    printf("Please, enter a position Q: ");
    scanf("%d", &posQ);
    printf("Please, enter a number K: ");
    scanf("%d", &numK);
    
    if ((posP + posQ) <= numK) 
    {
        printf("overlapping");
    } 
    else if ((posP + numK) > 32 || (posQ + numK) > 32)
    {
        printf("out of range");
    }
    else
    {
        size_t i, indexP, indexQ;
        for (i = 0, indexP = posP, indexQ = posQ; i < numK; i++, indexP++, indexQ++) 
        {
            int bitAtPPosition = (number >> indexP) & 1;
            int bitAtQPosition = (number >> indexQ) & 1;

            number = number & ~(1 << indexP);
            number = number | (bitAtQPosition << indexP);

            number = number & ~(1 << indexQ);
            number = number | (bitAtPPosition << indexQ);
        }
    
        printf("%u", number); 
    }
   
    return (EXIT_SUCCESS);
}