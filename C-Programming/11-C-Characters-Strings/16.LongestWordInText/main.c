/* 
 * Write a program to find the longest word in a text.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char** argv) 
{
    char *text = NULL, *word = NULL;
    size_t textSize = 0, maxLength = 0;
    printf("Please, enter any text: ");
    size_t textLen = getline(&text, &textSize, stdin);
    text[textLen - 1] = '\0';
    char delimiters[12] = " ,.:;!?\t\\|/";
    
    char *token = strtok(text, delimiters);
    while (token)
    {
        size_t wordLength = strlen(token);
        if (wordLength > maxLength) 
        {
            word = token;
            maxLength = wordLength;
        }
        token = strtok(NULL, delimiters);
    }

    printf("%s\n", word);
    free(text);
        
    return (EXIT_SUCCESS);
}