/* 
 * Write a function that takes a string as input and replaces all occurrences of
 * a digit (0-9) with a slash '/'.
 * The function should NOT modify the original string. 
 * It should return the resulting string as result. 
 * The function should also notify the calling function how many digits were replaced.
 * Find a way to do this using pointer parameters.
 */
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#define LENGHT 200

char *str_replacer(char *string, int *digits, int lenght);

int main(int argc, char** argv) 
{
    char string[LENGHT], *result;
    int digits = 0, lenght;
    printf("Please, enter a string: ");
    fgets(string, LENGHT, stdin);
    lenght = strlen(string);
    
    result = str_replacer(string, &digits, lenght);
    printf("string: %sdigits: %d\n", result, digits);
    
    free(result);
    return (0);
}

char *str_replacer(char *string, int *digits, int lenght)
{
    char *result = malloc(lenght * sizeof(char));
    int i;
    for (i = 0; i < lenght; i++) 
    {
        if (*(string + i) >= '0' && *(string + i) <= '9') 
        {
             *(result + i) = '/';
             (*digits)++;
        } 
        else 
        {
            *(result + i) = *(string + i);
        }
    }
    return result;
}