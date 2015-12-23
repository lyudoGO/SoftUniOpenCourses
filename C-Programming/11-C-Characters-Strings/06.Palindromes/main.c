/* 
 * Write a program that extracts from a given text all palindromes, 
 * e.g. ABBA, lamal, exe and prints them on the console on a single line, 
 * separated by comma and space. Use spaces, commas, dots, question marks and 
 * exclamation marks as word delimiters. Print only unique palindromes, 
 * sorted lexicographically. String comparison should be case-sensitive.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>  
#define PALINDROME_COUNT 8

int is_palindrome(char *word, char wordLen);
void print_palindromes(char **palindromes, size_t size);
int is_contains(char **palindromes, char *palindrome, size_t size);
int str_cmp(const void *first, const void *second) ;

int main(int argc, char** argv) 
{
    char *text = NULL, delemiters[6] = " .,?!";
    size_t textSize;
    printf("Please, enter a text: ");
    size_t textLen = getline(&text, &textSize, stdin);
    text[textLen - 1] = '\0';
    
    char **palindromes = calloc(PALINDROME_COUNT, sizeof(char *));
    if (!palindromes)
    {
        printf("Not enough memory!");
        return 1;
    }
    size_t count = 0;
    char *token = strtok(text, delemiters);
    while (token) 
    {
        size_t wordLen = strlen(token);
        if (is_palindrome(token, wordLen)) 
        {
            palindromes[count] = malloc(wordLen);
            
            if (!is_contains(palindromes, token, count))
            {
                strcpy(palindromes[count], token);
                count++;
            }
        }
        token = strtok(NULL, delemiters);
    }
    
    size_t stringsLen = count - 1 / sizeof(char *);
    qsort(palindromes, stringsLen, sizeof(char *), str_cmp);
    print_palindromes(palindromes, count);
    
    // release memory
    while (count > 0) 
    {
        free(palindromes[count]);
        count--;
    }
    free(text);
    free(palindromes);
    
    return (EXIT_SUCCESS);
}

int is_palindrome(char *word, char wordLen)
{
    size_t i, isPalindrome = 1;
    for (i = 0; i < wordLen / 2; i++) 
    {
        if (word[i] != word[wordLen - 1 - i])
        {
            isPalindrome = 0;
        }
    }
    return isPalindrome;
}

void print_palindromes(char **palindromes, size_t size)
{
    size_t i;
    for (i = 0; i < size; i++) 
    {
        if (i == size - 1) 
        {
            printf("%s\n", palindromes[i]);
        } 
        else 
        {
            printf("%s, ", palindromes[i]);
        }
    }
}

int is_contains(char **palindromes, char *palindrome, size_t size)
{
    size_t i, isContains = 0;
    for (i = 0; i <= size; i++) 
    {
        if (strstr(palindromes[i], palindrome))
        {
            isContains = 1;
            break;
        }
    }
    return isContains;
}

/* qsort C-string comparison function */ 
int str_cmp(const void *first, const void *second) 
{ 
    const char *ptrFirst = *(const char **)first;
    const char *ptrSecond = *(const char **)second;
    size_t firstLen = strlen(first);
    size_t secondLen = strlen(second);
    char lowerFirst[firstLen],  lowerSecond[secondLen];
    strcpy(lowerFirst, ptrFirst);
    strcpy(lowerSecond, ptrSecond);
    
    return strcmp(strlwr(lowerFirst), strlwr(lowerSecond));
} 