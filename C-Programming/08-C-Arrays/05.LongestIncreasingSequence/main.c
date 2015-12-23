#include <stdio.h>
#include <stdlib.h>

void print_sequences(int numbers[], int size);
void print_longest_sequence(int numbers[], int startIndex, int lenght);

int main(int argc, char** argv) {
    int count;
    printf("Please, enter count of numbers: ");
    scanf("%d", &count);

    int numbers[count];
    int i;
    for (i = 0; i < count; i++) {
        scanf("%d", &numbers[i]);
    }
    
    // find longest sequence
    int  startIndex = 0, lenght = 1, bestLenght = 1;
    for (i = 1; i < count; i++) {
        if (numbers[i] > numbers[i - 1]) {
            lenght++;
            if (lenght > bestLenght) {
                bestLenght = lenght;
                startIndex = i - bestLenght + 1;
            }
        }
        else {
            lenght = 1;
        }
    }
    
    printf("\n");
    print_sequences(numbers, count);
    print_longest_sequence(numbers, startIndex, bestLenght);
    
    return (0);
}

void print_sequences(int numbers[], int size) {
    int j;
    for (j = 1; j < size; j++) {
        printf("%d ", numbers[j - 1]);
        if (numbers[j] > numbers[j - 1]) {
            printf("%d ", numbers[j]);
            j++;
        }
        if (numbers[j] <= numbers[j - 1]) {
            printf("\n");
        }
        
        if (j == size - 1) {
           printf("%d", numbers[j]);
        }
    }
}

void print_longest_sequence(int numbers[], int startIndex, int lenght) {
    int i;
    printf("\nLongest: ");
    for (i = startIndex; i < startIndex + lenght; i++) {
        printf("%d ", numbers[i]);
    }
    printf("\n");
}