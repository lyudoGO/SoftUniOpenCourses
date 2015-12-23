#include <stdio.h>
#include <string.h>
#define SIZE 100

char reverse_string(char source[], char destionation[], int lenght, int index);

int main(int argc, char** argv) {
    char source[SIZE], destionation[SIZE];
    int index = 0, lenght; 
    printf("Please, enter any string: ");
    fgets(source, SIZE, stdin);
    lenght = strlen(source);
    source[lenght - 1] = '\0';
    
    reverse_string(source, destionation, lenght - 2, index);
    printf("%s", destionation);
    
    return (0);
}

char reverse_string(char source[], char destionation[], int lenght, int index) {
    if (lenght >= 0) {
        destionation[index] = source[lenght];
        reverse_string(source, destionation, lenght - 1, index + 1);
    }
    else {
        destionation[index] = '\0';
    }

}