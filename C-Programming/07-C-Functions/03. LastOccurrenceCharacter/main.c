#include <stdio.h>
#include <string.h>

int last_occurrenece_position(char ch, char* str);

int main(int argc, char** argv) {
    char str[300], ch;
    printf("Please, enter a string: ");
    fgets(str, sizeof str, stdin);
    printf("Please, enter a character: ");
    scanf(" %c", &ch);
    
    printf("Positon of %c is %d\n", ch, last_occurrenece_position(ch, str));
    
    return (0);
}

int last_occurrenece_position(char ch, char* str) {
    int i, size;
    size = strlen(str);
    for (i = size - 1; i >= 0; i--) {
        if (str[i] == ch) {
            return i;
        }
    }
    return -1;
}