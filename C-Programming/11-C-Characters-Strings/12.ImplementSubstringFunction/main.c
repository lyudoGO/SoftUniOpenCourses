/* 
 * Implement a function which extracts a substring from a given string 
 * by specifying the position from which to extract and the length to extract.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *sub_str(char *source, int position, int length);

int main(int argc, char** argv) 
{
    char *subStr = sub_str("Breaking Bad", 0, 2);
    printf("%s\n", subStr);
    
    char *subStrTwo = sub_str("Maniac", 3, 3);
    printf("%s\n", subStrTwo);
    
    char *subStrThree = sub_str("Maniac", 3, 5);
    printf("%s\n", subStrThree);
    
    char *subStrFour = sub_str("Master Yoda", 13, 5);
    printf("%s\n", subStrFour);
    
    free(subStr);
    free(subStrTwo);
    free(subStrThree);
    free(subStrFour);
    
    return (EXIT_SUCCESS);
}

char *sub_str(char *source, int position, int length)
{
    size_t sourceLen = strlen(source);
    char *emptyStr = malloc(1);
    emptyStr[0] = '\0';
    if (sourceLen <= position || 0 > position) 
    {
        return emptyStr;
    }

    char *subStr = malloc(length + 1);
    if (!subStr)
    {
        return emptyStr;
    }

    size_t i = position, index = 0;
    char ch = source[i];
    while (ch != '\0' && index < length)
    {
        subStr[index++] = ch;
        ch = source[++i];
    }

    subStr[index] = '\0';
    return subStr;
}