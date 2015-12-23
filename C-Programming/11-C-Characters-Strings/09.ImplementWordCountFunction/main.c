/* 
 * Implement a function which counts the words in a given input. 
 * The function accepts as parameter the input from which to count the words 
 * and the delimiter separating the words.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int str_word_count(char *string, char delimiter);

int main(int argc, char** argv) 
{
    printf("%d\n", str_word_count("Hard Rock, Hallelujah!", ' '));
    printf("%d\n", str_word_count("Hard Rock, Hallelujah!", ','));
    printf("%d\n", str_word_count("Uncle Sam wants you Man", ' '));
    printf("%d\n", str_word_count("Beat the beat!", '!'));
    
    return (EXIT_SUCCESS);
}

int str_word_count(char *string, char delimiter)
{
    size_t count = 1;
    while (*string != '\0')
    {
        if (*string == delimiter)
        {
            count++;
        }
        *string++;
    }
    return count;
}