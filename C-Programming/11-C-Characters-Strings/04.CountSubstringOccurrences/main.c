/* 
 * Write a program to find how many times a given string appears in a given 
 * text as substring. The text is given at the first input line. 
 * The search string is given at the second input line. 
 * The output is an integer number. Please ignore the character casing.
 * Overlapping between occurrences is allowed.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

int main(int argc, char** argv) 
{
    char *line = NULL, *string = NULL;
    size_t lineSize = 0, strSize = 0, count = 0;
    printf("Please, enter any string: ");
    size_t lineLen = getline(&line, &lineSize, stdin);
    line[lineLen - 1] = '\0';
    
    printf("Please, enter search string: ");
    size_t strLen = getline(&string, &strSize, stdin);
    //string[strLen - 1] = '\0';
    
    size_t i, j;
    for (i = 0; i <= lineLen - strLen; i++) 
    {
        int tempCount = 0;
        for (j = i; j < i + strLen; j++) 
        {
            if (tolower(line[j]) != tolower(string[j - i]))
            {
                tempCount = 0;
                break;
            }
            tempCount = 1;
        }
        count += tempCount;
    }

    printf("%d", count);
    free(line);
    free(string);
    return (EXIT_SUCCESS);
}
//Welcome to the Software University (SoftUni)! Welcome to programming. Programming is wellness for developers, said Maxwell.