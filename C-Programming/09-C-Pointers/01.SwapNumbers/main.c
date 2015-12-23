/* 
 * Implement a function which takes as input two numbers and swaps their values.
 * The declaration of the function should be something like:
 * void swap(int *first, int *second)
 */
#include <stdio.h>
#include <stdlib.h>

void swap(int *first, int *second);

int main(int argc, char** argv) 
{
    int first, second;
    printf("please, enter two integers: ");
    scanf("%d%d", &first, &second);
    
    printf("\nNumbers: %d %d", first, second);
    swap(&first, &second);
    printf("\nAfter swap: %d %d", first, second);
    return (0);
}

void swap(int *first, int *second)
{
    (*first) = (*first) ^ (*second);
    (*second) = (*first) ^ (*second);
    (*first) = (*first) ^ (*second);
}