#include <stdio.h>
#include <stdlib.h>

int get_index_largest(int array[], int size);

int main(int argc, char** argv) {

    int firstArr[] = { 1, 3, 4, 5, 1, 0, 5 };
    int secondArr[] = { 1, 2, 3, 4, 5, 6, 6 };
    int firstSize = sizeof(firstArr) / sizeof(int);
    int secondSize = sizeof(secondArr) / sizeof(int);
    
    int firstIndex = get_index_largest(firstArr, firstSize);
    int secondIndex = get_index_largest(secondArr, secondSize);
    
    printf("%d\n", firstIndex);
    printf("%d\n", secondIndex);
    return (0);
}

int get_index_largest(int array[], int size) {
    int i;
    for (i = 1; i <= size - 2; i++) {
        if (array[i - 1] < array[i] && array[i] > array[i + 1]) {
            return i;
        }
    }
    return -1;
}