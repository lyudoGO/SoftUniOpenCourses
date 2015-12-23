#include <stdlib.h>
#include "arrays.h"

int arr_min(int array[], int size) {
    int min = 0;
    int i;
    for (i = 0; i < size; i++) {
        if (array[i] < min) {
            min = array[i];
        }
    }
    return min;
}

int arr_max(int array[], int size) {
    int max = 0;
    int i;
    for (i = 0; i < size; i++) {
        if (array[i] > max) {
            max = array[i];
        }
    }
    return max;
}

void arr_clear(int array[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        array[i] = 0;
    }
}

long arr_average(int array[], int size) {
    long avr = 0;
    int i;
    for (i = 0; i < size; i++) {
        avr += array[i];
    }
    
    return avr / size;
}

long arr_sum(int array[], int size) {
    long sum = 0;
    int i;
    for (i = 0; i < size; i++) {
        sum += array[i];
    }
    
    return sum;
}

int arr_contains(int array[], int size, int element) {
    int i;
    for (i = 0; i < size; i++) {
        if (element == array[i]) {
            return 1;
        }
    }
    return 0;
}

void arr_print(int array[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}

int *arr_merge(int firstArray[], int firstSize, int secondArray[], int secondSize){
    int size = firstSize + secondSize;
    int *mergedArray =  malloc(size);
    
    int i;
    for (i = 0; i < size; i++) {
        if (i < firstSize) {
            mergedArray[i] = firstArray[i];
        } else {
            mergedArray[i] = secondArray[i - firstSize];
        }
    }

    return mergedArray;
}
