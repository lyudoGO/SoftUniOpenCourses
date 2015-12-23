#include <stdio.h>
#include <string.h>
#define INPUT_LENGHT 100

int main()
{
    char input[INPUT_LENGHT], *token;
    int numbers[INPUT_LENGHT], evenProduct = 1, oddProduct = 1;
    int isOdd = 1;
    printf("Please, enter a numbers: ");
    fgets(input, INPUT_LENGHT, stdin);
    int lenght = strlen(input);
    if (input[lenght - 1] == '\n')
    {
        input[lenght - 1] == '\0';
    }

    token = strtok(input, " .,-");
    while (token != NULL)
    {
        int num = atoi(token);
        if (isOdd)
        {
            oddProduct *= num;
        }
        else
        {
            evenProduct *= num;
        }
        isOdd = !isOdd;
        token = strtok(NULL, " .,-");
    }

    if (oddProduct == evenProduct)
    {
        printf("yes\n");
        printf("product = %d", oddProduct);
    }
    else
    {
        printf("no\n");
        printf("odd_product = %d\n", oddProduct);
        printf("even_product = %d\n", evenProduct);
    }
    return 0;
}
