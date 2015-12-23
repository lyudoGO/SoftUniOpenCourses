#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define SIZE 15

double reverse_number(char *number, int *error);

int main(int argc, char** argv) {
    char number[SIZE];
    int error;
    double result;
    printf("Please, enter a float-point number: ");
    fgets(number, SIZE, stdin);
    
    result = reverse_number(number, &error);
    if (error == 1) {
        printf("Invalid format");
    } else {
        printf("%.3f", result);
    }
   
    return (0);
}

double reverse_number(char *number, int *error) {
    int i;
    int length = strlen(number);
    char reversed[length];
    *error = 0;

    for (i = length - 2; i >= 0; i--)
    {
        reversed[length - 2 - i] = number[i];
    }
    reversed[length - 1] = '\0';
    char *endptr;
    double reversedDouble = strtod(reversed, &endptr);
    if (endptr == reversed)
    {
        *error = 1;
    }
    
    return reversedDouble;
}