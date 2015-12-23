#include <stdio.h>

int arr_reverse(int array[], int size);
void arr_print(int array[], int size);

int main(int argc, char** argv) {
    int size;
    printf("Please, enter array size:\n");
    scanf("%d", &size);
   
    int array[size];
    printf("Please, enter an array:\n");
    int i;
    for (i = 0; i < size; i++) {
        scanf("%d", &array[i]);
    }
    
    arr_reverse(array, size);
    arr_print(array, size);
    
    return (0);
}

int arr_reverse(int array[], int size) {
    int i;
    for (i = 0; i < size / 2; i++) {
        int temp = array[i];
        array[i] = array[size - i - 1];
        array[size - i - 1] = temp;
    }
}

void arr_print(int array[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}