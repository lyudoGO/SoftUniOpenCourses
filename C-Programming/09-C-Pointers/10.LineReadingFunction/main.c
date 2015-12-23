/* 
 * Write a function that reads an entire line from the standard input stream 
 * (console) and returns a pointer to the read string. The function should be 
 * able to read lines of unknown size.
 * Hint: Initially allocate a small buffer (use malloc()) and increase its size 
 * when it gets full (use realloc()).
 */
#include <stdio.h>
#include <stdlib.h>
#define BUFFER_SIZE 20

char *console_read_line();

int main(int argc, char** argv) {
    printf("Please, enter your text\n");
    char *line = console_read_line();
    printf("%s", line);
    
    free(line);
    
    return (0);
}

char *console_read_line()
{
    size_t size = BUFFER_SIZE;
    char *line = malloc(size);
    int position = 0;
    
    char symbol = getchar();
    while (symbol != '\n') 
    {
        if (position == size - 1) 
        {
            size *= 2; 
            line = realloc(line, size);
            if (!line) {
                *(line + position) = '\0';
                perror("Memory overflow!");
                return line;
            }
        }

        *(line + position) = symbol;
        position++;
        symbol = getchar();
    } 
    
    *(line + position) = '\0';
    return line;
}