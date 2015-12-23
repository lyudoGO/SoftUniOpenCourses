/* 
 * 
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#define BUFFER_SIZE 200

int main(int argc, char** argv) 
{
    char line[BUFFER_SIZE];
    fgets(line, BUFFER_SIZE, stdin);
    size_t lineLen = strlen(line);
    line[lineLen - 1] = '\0';
    
    double totalSum = 0;
    char *token = strtok(line, " ");
    while (token)
    {
        size_t tokenLen = strlen(token);
        char firstLetter = token[0];
        char lastLetter = token[tokenLen - 1];
        double number, currentSum = 0;
        char *ptr;
        number = strtod(token + 1, &ptr);
        if (isupper(firstLetter))
        {
            currentSum += (number / (firstLetter - 64));
        }
        else
        {
            currentSum += (number * (firstLetter - 96));
        }
        
        if (isupper(lastLetter))
        {
            currentSum -= (lastLetter - 64);
        } 
        else 
        {
            currentSum += (lastLetter - 96);
        }

        totalSum += currentSum;
        token = strtok(NULL, " ");
    }
    
    printf("%.2lf", totalSum + 0.0005);
    
    return (EXIT_SUCCESS);
}

