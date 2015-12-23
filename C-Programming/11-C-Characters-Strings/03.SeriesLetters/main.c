/* 
 * Write a program that reads a string from the console and replaces all 
 * series of consecutive identical letters with a single one.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define STRING_SIZE 300

int main(int argc, char** argv) 
{
    char *input, ch, temp;
    int lenght, i, index = 0;
    printf("Please, enter any string: ");
    fgets(input, STRING_SIZE, stdin);
    lenght = strlen(input);
    input[lenght - 1] = '\0';
    
    char result[lenght];
    ch = input[0];
    for (i = 1; i < lenght; i++) 
    {
        temp = input[i];
        if (ch != temp) 
        {
            result[index] = ch;
            index++;
            ch = temp;
        } 
        else 
        {
            ch = temp;
        }
    }
    result[index] = '\0';
    printf("%s", result);

    return (EXIT_SUCCESS);
}