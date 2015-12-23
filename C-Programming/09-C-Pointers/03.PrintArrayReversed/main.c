/* 
 * You are given a sample array as input and your task is to print the array 
 * in reversed order using pointer arithmetic instead of indexing.
 */
#include <stdio.h>
#include <stdlib.h>

void print_arr_reversed(int *array, size_t size);

int main(int argc, char** argv) 
{
    size_t size;
    printf("Please, enter array size: ");
    scanf("%d", &size);
    int i, array[size];
    printf("Please, enter array: ");
    for (i = 0; i < size; i++) {
        scanf("%d", &array[i]);
    }

    printf("Reversed array:\n");
    print_arr_reversed(array, size);
    return (0);
}

void print_arr_reversed(int *array, size_t size)
{
    int *ptr = (array + (size - 1));
    int i;
    for (i = 0; i < size; i++) 
    {
        printf("%d ", *(ptr - i));
    }
}