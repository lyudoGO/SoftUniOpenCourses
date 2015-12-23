#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int count;
    printf("Please, enter count of numbers: ");
    scanf("%d", &count);
    
    printf("Please, enter N integres separate with space:\n");
    int numbers[count];
    int i;
    for (i = 0; i < count; i++) {
        scanf("%d", &numbers[i]);
    }
    
    int j;
    for (j = 0; j < count; j++) {
        printf("%d ", numbers[j]);
    }

    return (0);
}