/* 
 * The standard C function size_t strlen(const char *s) returns the size of 
 * the input string. Try implementing it yourself. Think about how strings are 
 * represented in C in order to calculate their length.
 */
#include <stdio.h>
#include <stdlib.h>

size_t str_len(const char *string);

int main(int argc, char** argv) 
{
    char buffer[10] = { 'C', '\0', 'B', 'a', 'b', 'y' };
    printf("Soft -> %d\n", str_len("Soft"));
    printf("SoftUni -> %d\n", str_len("SoftUni"));
    printf("Buffer -> %d\n", str_len(buffer));
    
    // warning: initialization makes pointer from integer without a cast
    // char *bufferOne = { 'D', 'e', 'r', 'p' };
    // printf("BufferOne -> %d\n", str_len(bufferOne));

    return (EXIT_SUCCESS);
}

size_t str_len(const char *string)
{
    size_t index = 0;
    char symbol = string[index];
    while (symbol != '\0') 
    {
        index++;
        symbol = string[index];
    }
    return index;
}