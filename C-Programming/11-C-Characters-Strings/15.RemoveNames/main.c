/* 
 * Write a program that takes as input two lists of names and removes from the 
 * first list all names given in the second list. The input and output lists 
 * are given as words, separated by a space, each list at a separate line.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char** argv) 
{
    char *firstList = NULL, *secondList = NULL;
    size_t firstSize = 0, secondSize = 0;
    printf("Please, enter first list: ");
    size_t firstLen = getline(&firstList, &firstSize, stdin);
    printf("Please, enter second list: ");
    size_t secondLen = getline(&secondList, &secondSize, stdin);
    
    char *token = strtok(secondList, " ");
    while (token)
    {
        size_t tokenLen = strlen(token);
        char *subStr = strstr(firstList, token);
        while (subStr) 
        {
            size_t index = subStr - firstList;
            memmove(&firstList[index], &firstList[index + tokenLen + 1], firstLen - index);
            subStr = strstr(firstList, token);
        }
        token = strtok(NULL, " ");
    }
    
    printf("%s", firstList);
    free(firstList);
    free(secondList);
    
    return (EXIT_SUCCESS);
}