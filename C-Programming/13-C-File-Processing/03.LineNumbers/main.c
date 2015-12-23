/* 
 * Write a program that reads a text file and inserts line numbers in front of 
 * each of its lines. The result should be written to another text file.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    FILE *sourceFile = fopen("main.c", "r");
    if (!sourceFile) 
    {
        return 1;
    }
    FILE *destFile = fopen("modified-main.c", "w");
    if (!destFile) 
    {
        return 1;
    }
    
    char *line = NULL;
    size_t size = 0, number = 1;;
    while (!feof(sourceFile))
    {
        size_t length = getline(&line, &size, sourceFile);
        fprintf(destFile, "%d %s", number, line);
        number++;
    }
    free(line);
    fclose(sourceFile);
    fclose(destFile);

    return (EXIT_SUCCESS);
}