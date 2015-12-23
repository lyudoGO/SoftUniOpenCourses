#include <stdio.h>
#include <stdlib.h>

int arr_binary_search(int array[], int size, int number);

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

    int index = arr_binary_search(numbers, size, number);
    printf("%d\n", index);
    
    return (0);
}

int arr_binary_search(int array[], int size, int number) {
    int low = 0, high = size - 1;
    
    while (array[low] <= number && array[high] >= number) {
        int mid = (low + high) / 2;
        if (array[mid] < number) {
            low = mid + 1;
        }
        else if (array[mid] > number) {
            high = mid - 1;
        }
        else {
            return mid;
        }
    }
    
    if (array[low] == number) {
        return low;
    } else {
        return -1;
    }
}