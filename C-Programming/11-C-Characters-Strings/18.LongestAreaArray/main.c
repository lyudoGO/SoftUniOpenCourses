/* 
 * Write a program to find the longest area of equal elements in array of strings. 
 * You first should read an integer n and n strings (each at a separate line), 
 * then find and print the longest sequence of equal elements 
 * (first its length, then its elements). 
 * If multiple sequences have the same maximal length, print the leftmost of them.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *find_longest_area(char **elements, int size, int *maxCount);

int main(int argc, char** argv) 
{
    int size, maxCount = 0;
    printf("Please, enter number of elements: ");
    scanf("%d", &size);
    getchar();
    
    char *elements[size];
    int i, sizeLine = 0;
    for (i = 0; i < size; i++)
    {
        char *element = NULL;
        size_t length = getline(&element, &sizeLine, stdin);
        element[length - 1] = '\0';
        size_t elementLen = strlen(element);
        elements[i] = malloc(elementLen + 1);
        strcpy(elements[i], element);
        free(element);
    }  
    
    char *searchElement = find_longest_area(elements, size, &maxCount);
    
    printf("\n%d\n", maxCount);
    for (i = 0; i < maxCount; i++) 
    {
        printf("%s\n", searchElement);
    }

    return (EXIT_SUCCESS);
}

char *find_longest_area(char **elements, int size, int *maxCount)
{
    int i, j;
    char *searchElement;
    for (i = 0; i < size; i++) 
    {
        int currentCount = 0;
        for (j = i; j < size; j++) 
        {
            if (strcmp(elements[i], elements[j]) == 0) 
            {
                currentCount++;
                if (*maxCount < currentCount)
                {
                    *maxCount = currentCount;
                    searchElement = elements[i];
                }
            }
        }
    }  
    return searchElement;
}