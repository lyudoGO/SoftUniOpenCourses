/* 
 * Write a function that takes 2 pointers and swaps the memory they point to. 
 * The function should also take the size of each memory piece and should work
 * with any data type.
 */
#include <stdio.h>
#include <stdlib.h>

void swap(void *first, void *second, size_t size);

int main(int argc, char** argv) {
    char letter = 'B', symbol = '+';
    int a = 10, b = 6;
    double d = 3.14, f = 1.23567;
    
    swap(&letter, &symbol, sizeof(char));
    printf("%c %c\n", letter, symbol);
    
    swap(&a, &b, sizeof(int));
    printf("%d %d\n", a, b);

    swap(&d, &f, sizeof(double));
    printf("%.2lf %.2lf\n", d, f);

    return (EXIT_SUCCESS);
}

void swap(void *first, void *second, size_t size)
{
    char *memoryFirstPtr = first;
    char *memorySecondPtr = second;
    int i;
    for (i = 0; i < size; i++) {
        char temp = memoryFirstPtr[i];
        memoryFirstPtr[i] = memorySecondPtr[i];
        memorySecondPtr[i] = temp;
    }
}