/* 
 * Write a program that reads a text file and prints on the console its odd lines.
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    FILE *file = fopen("text.txt", "r");
    if (!file) 
    {
        return 1;
    }
    
    char *line = NULL;
    size_t size = 0, count = 1;
    while (!feof(file)) 
    {
        size_t length = getline(&line, &size, file);
        if (count % 2 != 0) 
        {
            printf("%s", line);
        }
        count++;
    }
    
    free(line);
    fclose(file);
    
    return (EXIT_SUCCESS);
}