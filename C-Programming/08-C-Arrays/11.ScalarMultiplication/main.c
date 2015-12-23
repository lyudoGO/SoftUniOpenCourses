#include <stdio.h>
#include <stdlib.h>

void arr_print(int array[], int size);

int main(int argc, char** argv) {

    int size, scalar;
    printf("Please, enter a size: ");
    scanf("%d", &size);
    printf("Please, enter a scalar: ");
    scanf("%d", &scalar);
    printf("Please, enter a array:\n");
    int i, array[size];
    for (i = 0; i < size; i++) {
        scanf("%d", &array[i]);
    }

    int j;
    for (j = 0; j < size; j++) {
        array[j] *= scalar;
    }
    
    arr_print(array, size);
    
    return (EXIT_SUCCESS);
}

void arr_print(int array[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}