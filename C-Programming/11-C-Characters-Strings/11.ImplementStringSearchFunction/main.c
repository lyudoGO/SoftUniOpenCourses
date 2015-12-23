/* 
 * Implement a function which checks whether a string appears as a substring in
 * another string. It should return 1 if the string occurs and 0 if it does not.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int str_search(char * source, char * substr);

int main(int argc, char** argv) 
{
    printf("%d\n", str_search("SoftUni", "Soft"));
    printf("%d\n", str_search("Hard Rock", "Rock"));
    printf("%d\n", str_search("Ananas", "nasa"));
    printf("%d\n", str_search("Coolness", "cool"));
    
    return (EXIT_SUCCESS);
}

int str_search(char * source, char * substr)
{
    size_t sourceLen = strlen(source);
    size_t substrLen= strlen(substr);
    if (substrLen > sourceLen)
    {
        return 0;
    }

    size_t i, j;
    for (i = 0; i < sourceLen; i++) 
    {
        for (j = 0; j < substrLen; j++) 
        {
            if (source[j + i] != substr[j])
            {
                break;
            }
        }
        if (j == substrLen)
        {
            return 1;
        }

    }
    return 0;
}