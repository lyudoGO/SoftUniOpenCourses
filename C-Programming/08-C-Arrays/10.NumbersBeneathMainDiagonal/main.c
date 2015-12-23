#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    int count;
    printf("Please, enter rows and cols count: ");
    scanf("%d", &count);
    int matrix[count][count];
    
    int i, j;
    for (i = 0; i < count; i++) {
        for (j = 0; j < count; j++) {
            scanf("%d", &matrix[i][j]);
        }
    }

    printf("\n");
    
    for (i = 0; i < count; i++) {
        for (j = 0; j <= i; j++) {
            printf("%-3d ", matrix[i][j]);
        }
        printf("\n");
    }
    
    return (0);
}