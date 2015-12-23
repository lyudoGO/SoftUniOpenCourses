#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "arrays.h"

int main(int argc, char** argv) {
    int array[8] = { -12, 0, 5, 4, 907, -55, 1, 67 };
    int size = sizeof(array) / sizeof(int);
    
    int min = arr_min(array, size);
    int max = arr_max(array, size);
    long average = arr_average(array, size);
    long sum = arr_sum(array, size);
    int isContainsA = arr_contains(array, size, 1000);
    int isContainsB = arr_contains(array, size, -12);
    
    printf("Array is: ");
    arr_print(array, size);
        
    printf("Min = %d\nMax = %d\n", min, max);
    printf("Average = %d\nSum = %d\n", average, sum);
    printf("Contains 1000 -> %s\n", (isContainsA == 1) ? "true" : "false");
    printf("Contains -12 -> %s\n", (isContainsB == 1) ? "true" : "false");

    int arrayTwo[5] = { 10, 20, 30, 40, 50 };
    int sizeTwo = sizeof(arrayTwo) / sizeof(int);
    int *mergedArray = arr_merge(array, size, arrayTwo, sizeTwo);

    printf("Merged array is: ");
    arr_print(mergedArray, size + sizeTwo);
            
    arr_clear(array, size);
    printf("After clear array is: ");
    arr_print(array, size);
    
    return (0);
}