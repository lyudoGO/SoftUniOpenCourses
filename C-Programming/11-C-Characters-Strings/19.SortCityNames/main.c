/* 
 * You are given a list of cities. You have to process them and sort them in 
 * ascending order. On the first input line, you are given the count of the 
 * cities. Use an algorithm other than bubble sort.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int str_cmp(const void *first, const void *second);

int main(int argc, char** argv) 
{
    int num, size = 0;
    printf("Please, enter number of sities: ");
    scanf("%d", &num);
    getchar();
    
    char *cities[num];
    int i;
    for (i = 0; i < num; i++)
    {
        char *city = NULL;
        size_t length = getline(&city, &size, stdin);
        city[length - 1] = '\0';
        size_t cityLen = strlen(city);
        cities[i] = malloc(cityLen + 1);
        strcpy(cities[i], city);
        free(city);
    }

    qsort(cities, num, sizeof(char *), str_cmp);  
    
    printf("\n");
    for (i = 0; i < num; i++) 
    {
        printf("%s\n", cities[i]);
        free(cities[i]);
    }

    return (EXIT_SUCCESS);
}

int str_cmp(const void *first, const void *second) 
{ 
    const char *ptrFirst = *(const char **)first;
    const char *ptrSecond = *(const char **)second;
    
    return strcmp(ptrFirst, ptrSecond);
} 