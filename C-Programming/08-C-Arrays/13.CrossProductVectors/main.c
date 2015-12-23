#include <stdio.h>
#include <stdlib.h>
#define SIZE 3

void vector_cross_product(int firstArray[], int secondArray[], int crossArray[]);
void arr_print(int array[], int size);

int main(int argc, char** argv) {
    int firstArray[SIZE], secondArray[SIZE], crossArray[SIZE];
    printf("Please, enter a first array:\n");
    int i, j;
    for (i = 0; i < SIZE; i++) {
        scanf("%d", &firstArray[i]);
    }
    printf("Please, enter a second array:\n");
    for (j = 0; j < SIZE; j++) {
        scanf("%d", &secondArray[j]);
    }
    
    vector_cross_product(firstArray, secondArray, crossArray);
    arr_print(crossArray, SIZE);
    return (0);
}

void vector_cross_product(int firstArray[], int secondArray[], int crossArray[]) {
    crossArray[0] = firstArray[1] * secondArray[2] - firstArray[2] * secondArray[1];
    crossArray[1] = firstArray[2] * secondArray[0] - firstArray[0] * secondArray[2];
    crossArray[2] = firstArray[0] * secondArray[1] - firstArray[1] * secondArray[0];
}

void arr_print(int array[], int size) {
    int i;
    printf("[");
    for (i = 0; i < size; i++) {
        if (i == size - 1) {
            printf("%d]", array[i]);
        } else {
            printf("%d, ", array[i]);
        }
    }
}