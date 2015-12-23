#include <stdio.h>
#include <stdlib.h>

void print_matrix(int *matrix, int rows);

int main(int argc, char** argv) {
    int rows, cols;
    printf("Please, enter rows: ");
    scanf("%d", &rows);
    printf("Please, enter cols: ");
    scanf("%d", &cols);
    
    int firstMatrix[rows][cols], secondMatrix[cols][rows], matrix[rows][rows];
    printf("Please, enter first matrix:\n");
    int i, j;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            scanf("%d", &firstMatrix[i][j]);
        }
    }

    printf("Please, enter second matrix:\n");
    for (i = 0; i < cols; i++) {
        for (j = 0; j < rows; j++) {
            scanf("%d", &secondMatrix[i][j]);
        }
    }
    
    // multiplication of matrices
    int k;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < rows; j++) {
            matrix[i][j] = 0;
            for (k = 0; k < cols; k++) {
                matrix[i][j] += firstMatrix[i][k] * secondMatrix[k][j];
            }
        }
    }
    print_matrix(&matrix[0][0], rows);
    
    return (0);
}

void print_matrix(int *matrix, int rows) {
    int i, j;
    printf("Matrix: \n");
    for (i = 0; i < rows; i++) {
        for (j = 0; j < rows; j++) {
            printf("%-5d", matrix[i * rows + j]);
        }
        printf("\n");
    }
}