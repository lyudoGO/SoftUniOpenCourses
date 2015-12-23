/* 
 * Write a program that takes a text and a string of banned words. 
 * All words included in the ban list should be replaced with asterisks "*", 
 * equal to the word's length. The entries in the ban list will be separated 
 * by a comma and space ", ". The ban list should be entered on the first input 
 * line and the text on the second input line.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char** argv) 
{
    char *text = NULL, *words = NULL;
    size_t textSize = 0, strSize = 0;
    printf("Please, enter string of banned word: ");
    size_t strLen = getline(&words, &strSize, stdin);
    words[strLen - 1] = '\0';
    
    printf("Please, enter a text: ");
    size_t textLen = getline(&text, &textSize, stdin);
    
    char *token = strtok(words, ", ");
    while (token) 
    {
        size_t wordLen = strlen(token);
        char *subStr = strstr(text, token);
        while (subStr) 
        {
            int index = subStr - text;
            memset(&text[index], '*', wordLen);
            subStr = strstr(&text[index + wordLen], token);
        }
        token = strtok(NULL, ", ");
    }

    printf("%s\n", text);
    
    free(text);
    free(words);
    
    return (EXIT_SUCCESS);
}