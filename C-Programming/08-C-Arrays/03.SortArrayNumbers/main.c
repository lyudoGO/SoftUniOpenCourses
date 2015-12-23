#include <stdio.h>

void print_numbers(int numbers[], int size);
void sort_numbers(int numbers[], int size);

int main(int argc, char** argv) {

    int count;
    printf("Please, enter count of numbers: ");
    scanf("%d", &count);

    int numbers[count];
    int i;
    for (i = 0; i < count; i++) {
        scanf("%d", &numbers[i]);
    }

    sort_numbers(numbers, count);
    print_numbers(numbers, count);
    return (0);
}

void sort_numbers(int numbers[], int size) {
    int i, j;
    for (i = 0; i < size; i++) {
        for (j = i; j < size; j++) {
            if (numbers[j] < numbers[i]) {
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }
    }
}

void print_numbers(int numbers[], int size) {
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", numbers[i]);
    }
}