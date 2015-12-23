/* 
 * Write a function that takes a pointer of any type, size of bytes n and 
 * row length len. The function should print a total of n bytes, starting from 
 * the address of the pointer.
 * The output should be formatted into several rows, each holding len bytes. 
 * At the start of each row, print the address of the initial byte.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void memory_dump(void *input, size_t size, int lenghtRow);

int main(int argc, char** argv) {
    char *text = "I love to break free";
    int array[] = { 7, 3, 2, 10, -5};
    size_t size = sizeof(array) / sizeof(int);
    
    printf("\nText:");
    memory_dump(text, strlen(text) + 1, 5);
    printf("\nArray:");
    memory_dump(array, size * sizeof(int), 4);
    
    return (EXIT_SUCCESS);
}

void memory_dump(void *input, size_t size, int lenghtRow)
{
    char *inputPtr = input;
    int i;
    for (i = 0; i < size; i++)
    {
        if (i % lenghtRow == 0)
        {
            printf("\n%p\t", &inputPtr[i]);
        }

        printf("%02hhx  ", *inputPtr);
        inputPtr++;
    }
}