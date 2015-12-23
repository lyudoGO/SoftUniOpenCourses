#include <stdio.h>
#include <stdlib.h>

int arr_binary_search(int array[], int number, int start, int end);

int main(int argc, char** argv) {
    int size, number;
    printf("Please, enter collection size: ");
    scanf("%d", &size);
    
    int i, numbers[size];
    printf("Please, enter sorted collection on one line: ");
    for (i = 0; i < size; i++) {
        scanf("%d", &numbers[i]);
    }
    
    printf("Please, enter a number: ");
    scanf("%d", &number);

    int index = arr_binary_search(numbers, number, 0, size - 1);
    printf("%d\n", index);
    
    return (0);
}

int arr_binary_search(int array[], int number, int start, int end) {
    if (end < start)
    {
        return -1;
    }

    int middle = start + (end - start) / 2;
    if (array[middle] > number)
    {
        return arr_binary_search(array, number, start, middle - 1); 
    }

    if (array[middle] < number)
    {
        return arr_binary_search(array,number,  middle + 1, end); 
    }

    return middle;
}