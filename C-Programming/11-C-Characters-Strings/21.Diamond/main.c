/* 
 * You are given as input a number which represents the height and width of a 
 * diamond. Your task is to draw it according to the given metrics.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void print_row(int num, int row);

int main(int argc, char** argv) 
{
    size_t num;
    printf("Please, enter a number: ");
    scanf("%d", &num);
    
    int i;
    for (i = 0; i < num / 2; i++) 
    {
        print_row(num, i);
    }

    for (i = num / 2; i >= 0; i--) 
    {
        print_row(num, i);
    }
    return (EXIT_SUCCESS);
}

void print_row(int num, int row)
{
    int j;
    for (j = 0; j < num; j++) 
    {
        if (j == (num / 2 - row) || j == (num / 2 + row))
        {
            printf("%c", '*');
        } else 
        {
            printf("%c", '.');
        }
    }
    printf("\n");
}