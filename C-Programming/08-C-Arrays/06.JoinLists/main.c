#include <stdio.h>
#include <stdlib.h>

int *arr_merge(int firstArray[], int firstSize, int secondArray[], int secondSize);
int arr_sort(int mergedArray[], int size);
int arr_remove_dublicates(int newArr[], int mergedArray[], int size);
void arr_print(int array[], int size);

int main(int argc, char** argv) {
    int firstSize, secondSize, size;
    printf("Please, enter arrays size:\n");
    scanf("%d", &firstSize);
    scanf("%d", &secondSize);
    
    size = firstSize + secondSize;
    
    int firstArr[firstSize], secondArr[secondSize];
    printf("Please, enter two arrays:\n");
    int i, j;
    for (i = 0; i < firstSize; i++) {
        scanf("%d", &firstArr[i]);
    }
    for (j = 0; j < secondSize; j++) {
        scanf("%d", &secondArr[j]);
    }
    
    int *mergedArray = arr_merge(firstArr, firstSize, secondArr, secondSize);
    arr_sort(mergedArray, size);
 
    int newArray[size];
    int index = arr_remove_dublicates(newArray, mergedArray, size); 
    arr_print(newArray, index);
    
    return (0);
}

int arr_remove_dublicates(int newArray[], int mergedArray[], int size) {
    int i, index = 1;
    newArray[0] = mergedArray[0];
    for (i = 1; i < size; i++) {
        if (mergedArray[i - 1] == mergedArray[i]) {
            continue;
        }
        else {
            newArray[index] = mergedArray[i];
            index++;
        }
    }
    
    return index;
}

int arr_sort(int array[], int size) {
    int i;
    for (i = 1; i < size; i++) {
        int targetIndex = i;

        while(targetIndex > 0 && array[targetIndex - 1] > array[targetIndex]) {
            int temp = array[targetIndex];
            array[targetIndex] = array[targetIndex - 1];
            array[targetIndex - 1] = temp;
            targetIndex--;
        }
    }
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

void arr_print(int array[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", array[i]);
    }
    printf("\n");
}