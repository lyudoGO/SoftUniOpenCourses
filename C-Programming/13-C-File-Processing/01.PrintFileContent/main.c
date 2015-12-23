/* 
 * Write a program that reads a text file and prints its contents on the console.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    FILE *file = fopen("main.c", "r");
    if (!file)
    {
        return 1;       
    }
    char *line = NULL;
    size_t size = 0;
    
    while (!feof(file))
    {
        ssize_t length = getline(&line, &size, file);
        printf("%s", line);
    }
    
    free(line);
    fclose(file);
    return (EXIT_SUCCESS);
}