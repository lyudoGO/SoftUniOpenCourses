/* 
 * Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters 
 * should be filled with asterisks '*'. Print the resulting string on the console.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define STRING_SIZE 20

int main(int argc, char** argv) 
{
    char input[STRING_SIZE + 1];
    int lenght, i;
    printf("Please, enter any string: ");
    fgets(input, STRING_SIZE + 1, stdin);
    lenght = strlen(input);
    
    if (input[lenght] == '\n') 
    {
        i = lenght;
    }
    if (input[lenght - 1] == '\n') 
    {
        i = lenght - 1;
    }
    for (i; i < STRING_SIZE; i++) 
    {
        input[i] = '*';
    }
    input[STRING_SIZE] = '\0';

    printf("%s", input);
    return (EXIT_SUCCESS);
}