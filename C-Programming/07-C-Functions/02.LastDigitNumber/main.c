#include <stdio.h>
#include <stdlib.h>

char* get_last_digit(int number);

int main(int argc, char** argv) {
    int number;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    
    printf("%s\n", get_last_digit(number));
            
    return (0);
}

char* get_last_digit(int number) {
    int lastDigit = number % 10;
    switch (lastDigit) {
        case 0: return "zero"; break;
        case 1: return "one"; break;
        case 2: return "two"; break;
        case 3: return "three"; break;
        case 4: return "four"; break;
        case 5: return "five"; break;
        case 6: return "six"; break;
        case 7: return "seven"; break;
        case 8: return "eight"; break;
        case 9: return "nine"; break;
        default: return "error";break;
    }
}
