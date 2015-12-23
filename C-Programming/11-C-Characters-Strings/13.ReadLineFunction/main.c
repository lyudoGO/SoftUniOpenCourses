/* 
 * Write a function that reads an entire line from the standard input stream 
 * (until end of line ('\n') or end of file (EOF) and returns a pointer to the 
 * read string. The function should be able to read lines of unknown size. 
 * The returned string's length should be equal to its allocated memory.
 */
#include <stdio.h>
#include <stdlib.h>
#define BUFFER_LENGHT 64

char *read_line();

int main(int argc, char** argv) 
{
    printf("Please, enter any string: ");
    char *line = read_line();
    if (!line)
    {
        printf("Memory error!");
        return 1;
    }

    printf("%s", line);
    free(line);
    return (EXIT_SUCCESS);
}

char *read_line()
{
    char *line = malloc(BUFFER_LENGHT);
    if (!line) 
    {
        return NULL;
    }
    size_t index = 0, lenght = BUFFER_LENGHT;
    char ch = getchar();
    while (ch != '\n' && ch != EOF) 
    {
        if (index == lenght - 1) 
        {
            char *resizedLine = realloc(line, 2 * lenght);
            if (!resizedLine) 
            {
                line[index] = '\0';
                return line;
            }
            line = resizedLine;
            lenght *= 2;
        }

        line[index] = ch;
        index++;
        ch = getchar();
    }
    line[index] = '\0';
    return line;
}

//char *get_line(char **line, size_t *size)
//{
//    size_t index = 0, lenght = *size;
//    char *result = *line;
//    if (result == NULL) 
//    {
//        result = malloc(BUFFER_LENGHT);
//        lenght = BUFFER_LENGHT;
//        if (!result)
//        {
//            return NULL;
//        }
//    }
//    char ch = getchar();
//    while (ch != '\n' && ch != EOF) 
//    {
//        if (index == lenght - 1) 
//        {
//            char *resizedLine = realloc(line, 2 * lenght);
//            if (!resizedLine) 
//            {
//                result[index] = '\0';
//                return result;
//            }
//            result = resizedLine;
//            lenght *= 2;
//        }
//
//        result[index] = ch;
//        index++;
//        ch = getchar();
//    }
//    result[index] = '\0';
//    *line = result;
//    *size = lenght;
//    return result;
//}