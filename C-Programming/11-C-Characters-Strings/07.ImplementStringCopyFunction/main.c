/* 
 * The standard C function strncpy(char *dest, const char *src, size_t n) 
 * copies a chunk from the src string to the dest buffer. 
 * Try implementing that function manually. Try doing it without a buffer, 
 * by returning a string created in the body of the function. Does it work? 
 * Think why it does or it doesn't. How can you modify it to work/break it.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define STRING_LENGHT 16

char *str_n_cpy(char *destination, const char *source, size_t size);

int main(int argc, char** argv) 
{
    char destination[STRING_LENGHT], 
         destinationTwo[STRING_LENGHT], 
         destinationThree[STRING_LENGHT];
    
    str_n_cpy(destination, "SoftUni", 7);
    printf("%s\n", destination);

    str_n_cpy(destinationTwo, "SoftUni", 3);
    printf("%s\n", destinationTwo);
    
    str_n_cpy(destinationThree, "C is cool", 0);
    printf("%s\n", destinationThree);
    
    // don't compile, wrong number of argument 
    // char* result = str_n_cpy("SoftUni", 7);
    
    return (EXIT_SUCCESS);
}

char *str_n_cpy(char *destination, const char *source, size_t size)
{
    size_t i;
    for (i = 0; i < size; i++) 
    {
        destination[i] = source[i];
    }
    destination[size] = '\0';
    
    return destination;
}