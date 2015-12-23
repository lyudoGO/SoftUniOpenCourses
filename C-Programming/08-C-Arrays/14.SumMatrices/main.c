#include <stdio.h>
#include <stdlib.h>

void sum_matrix(int *firstMatrix, int *secondMatrix, int *matrix, int rows, int cols);
void print_matrix(int *matrix, int rows, int cols);

int main(int argc, char** argv) {
    int rows, cols;
    printf("Please, enter rows: ");
    scanf("%d", &rows);
    printf("Please, enter cols: ");
    scanf("%d", &cols);
    
    int firstMatrix[rows][cols], secondMatrix[rows][cols], matrix[rows][cols];
    printf("Please, enter first matrix:\n");
    int i, j;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            scanf("%d", &firstMatrix[i][j]);
        }
    }

    printf("Please, enter second matrix:\n");
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            scanf("%d", &secondMatrix[i][j]);
        }
    }

    sum_matrix(&firstMatrix[0][0], &secondMatrix[0][0], &matrix[0][0], rows, cols);
    print_matrix(&matrix[0][0], rows, cols);
    
    return (0);
}

void sum_matrix(int *firstMatrix, int *secondMatrix, int *matrix, int rows, int cols) {
    int i, j;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            matrix[i * cols + j] = firstMatrix[i * cols + j] + secondMatrix[i * cols + j];
        }
    }
}

void print_matrix(int *matrix, int rows, int cols) {
    int i, j;
    printf("Matrix: \n");
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            printf("%-3d", matrix[i * cols + j]);
        }
        printf("\n");
    }
}