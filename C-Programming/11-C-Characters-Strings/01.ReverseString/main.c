/* 
 * Write a program that reads a string from the console, reverses it and
 *  prints the result back at the console.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define STRING_SIZE 100

char *str_reverse(char *input, size_t lenght);

int main(int argc, char** argv) 
{
    char *input;
    int lenght;
    printf("Please, enter any string: ");
    fgets(input, STRING_SIZE, stdin);
    lenght = strlen(input);
    input[lenght - 1] = '\0';
    char *result = str_reverse(input, lenght);
    
    printf("%s", result);
    free(result);
    return (EXIT_SUCCESS);
}

char *str_reverse(char *input, size_t lenght)
{
    char *result = malloc(lenght + 1);
    if (!result) 
    {
        return "No enough memory";
    }

    int i;
    for (i = lenght - 2; i >= 0; i--) {
        result[lenght - 2 - i] = input[i];
    }
    result[lenght - 1] = '\0';
 
    return result;
}