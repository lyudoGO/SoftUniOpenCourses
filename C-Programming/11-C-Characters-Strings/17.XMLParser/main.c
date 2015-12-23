/* 
 * Write a program that reads n lines in XML format and parses their contents. 
 * A line is considered valid if it follows the format <{tag}>{data}</{tag}>. 
 * In case of invalid line format, print "Invalid format".
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

char *xml_parse(char *line);

int main(int argc, char** argv) 
{
    char *line = NULL, *tag = NULL;
    size_t lineSize = 0;
    printf("Please, enter tags to parse and press enter\n");
    size_t lineLen = getline(&line, &lineSize, stdin);
    line[lineLen - 1] = '\0';
    
    int i;
    for (i = 0; i < 3; i++) 
    {
        char *result = xml_parse(line);
        if (!result)
        {
            printf("Invalid format\n");
        }
        else
        {
            printf("%s\n", result);
        }
        free(result);
        getline(&line, &lineSize, stdin);
    }
    
    free(line);
    return (EXIT_SUCCESS);
}

char *xml_parse(char *line)
{
    char *firstOpBracket = strchr(line, '<');
    if (!firstOpBracket) return NULL;

    char *firstClBracket = strchr(firstOpBracket + 1, '>');
    if (!firstClBracket) return NULL;

    char *secondOpBracket = strstr(firstClBracket + 1, "</");
    if (!secondOpBracket) return NULL;

    char *secondClBracket = strchr(secondOpBracket, '>');
    if (!secondClBracket) return NULL;

    char *firstTag = firstOpBracket + 1;
    firstClBracket[0] = '\0';

    char *secondTag = secondOpBracket + 2;
    secondClBracket[0] = '\0';  
    if (strcmp(firstTag, secondTag))
    {
       return NULL;
    }

    secondOpBracket[0] = '\0';
    char *data = firstClBracket + 1;
    firstTag[0] = toupper(firstTag[0]);

    char *result = malloc(strlen(firstTag) + strlen(data) + 3);
    if (!result)
    {
       return NULL;
    }

    sprintf(result, "%s: %s", firstTag, data); 
    return result;
}