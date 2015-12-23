/* 
 * You are given a square matrix of city names. Your task is to print the names
 * of those cities which are stationed on the matrix's main diagonal. 
 * On the first input line you are given the count of the rows. 
 * The names of the cities will consist of one word only.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char** argv) 
{
    int rows;
    printf("Please, enter rows: ");
    scanf("%d", &rows);
    getchar();
    char *matrix[rows], *line = NULL;
    size_t lineSize = 0;
    int i;
    for (i = 0; i < rows; i++) 
    {
        size_t lineLen = getline(&line, &lineSize, stdin);
        line[lineLen - 1] = '\0';
        
        char *token = strtok(line, " ");
        int tokenCount = 0;
        while (token)
        {
            if (tokenCount == i)
            {  
                size_t tokenLen = strlen(token);
                token[tokenLen] = '\0';
                matrix[i] = calloc(tokenLen + 1, sizeof(char));
                strcpy(matrix[i], token);
            }
            tokenCount++;
            token = strtok(NULL, " ");
        }
        free(line);
    }

//    for (i = 0; i < rows; i++) 
//    {
//        printf("%p", (matrix[i]));
//    }
//
//    free(matrix);
    return (EXIT_SUCCESS);
}

