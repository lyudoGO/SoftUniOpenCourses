/* 
 * Write a program to generate the following matrix of palindromes of 3 letters 
 * with r rows and c columns.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int rows, cols;
    printf("Please, enter rows and cols: ");
    scanf("%d%d", &rows, &cols);

    char symbol = 'a';
    size_t i, j;
    for (i = 0; i < rows; i++) 
    {
        for (j = 0; j < cols; j++) 
        {
            printf("%c%c%c ", symbol, symbol + j, symbol);
        }
        symbol += 1;
        printf("\n");
    }

    return (EXIT_SUCCESS);
}