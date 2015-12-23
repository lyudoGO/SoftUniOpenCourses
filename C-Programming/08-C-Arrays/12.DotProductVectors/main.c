#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    int size;
    printf("Please, enter a size: ");
    scanf("%d", &size);
    
    int firstArray[size], secondArray[size];
    printf("Please, enter a first array:\n");
    int i, j;
    for (i = 0; i < size; i++) {
        scanf("%d", &firstArray[i]);
    }
    printf("Please, enter a second array:\n");
    for (j = 0; j < size; j++) {
        scanf("%d", &secondArray[j]);
    }
    
    int product = 0;
    for (i = 0; i < size; i++) {
        product +=  firstArray[i] * secondArray[i];
    }
    
    printf("%d", product);
    
    return (0);
}