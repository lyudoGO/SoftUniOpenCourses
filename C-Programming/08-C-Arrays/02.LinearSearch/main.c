#include <stdio.h>
#include <stdlib.h>

void is_number_exist(int numbers[], int size, int number);

int main(int argc, char** argv) {

    int count, searchNum;
    printf("Please, enter count of numbers: ");
    scanf("%d", &count);
    
    printf("Please, enter N integres separate with space:\n");
    int numbers[count];
    int i;
    for (i = 0; i < count; i++) {
        scanf("%d", &numbers[i]);
    }
    
    printf("Please, enter a search number: ");
    scanf("%d", &searchNum);
    is_number_exist(numbers, count, searchNum);
    
    return (0);
}

void is_number_exist(int numbers[], int size, int number) {
    int j, isExist = 0;
    for (j = 0; j < size; j++) {
        if (number == numbers[j]) {
            isExist = 1;
        }
    }
    
    if (isExist == 1) {
        printf("%s", "yes\n");
    } else {
        printf("%s", "no\n");
    }
}