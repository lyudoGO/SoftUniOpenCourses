/* 
 * The standard C function strncat(char *dest, const char *src, size_t n) 
 * concatenates the strings located in the src and the dest buffer into the 
 * dest buffer. The variable n shows the length from the src string to be 
 * concatenated. Try implementing that function yourself.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *str_n_cat(char *destination, const char *source, size_t length);

int main(int argc, char** argv) 
{
    char buffer[10] = "Soft";
    str_n_cat(buffer, "Uni", 7);
    printf("%s\n", buffer);
    
    char bufferOne[5] = "Soft";
    str_n_cat(bufferOne, "ware University", 15);
    printf("%s\n", bufferOne);
    
    char bufferTwo[10] = "C";
    str_n_cat(bufferTwo, " is cool", 8);
    printf("%s\n", bufferTwo);
    
    // error, we try to write in read only memory *bufferThree
    //char * bufferThree = "C";
    //str_n_cat(bufferThree, " is cool", 8);
    //printf("%s\n", bufferThree);
 
    return (EXIT_SUCCESS);
}

char *str_n_cat(char *destination, const char *source, size_t length)
{
    size_t destSize = strlen(destination);
    int i;
    for (i = 0; i < length; i++) 
    {
        destination[i + destSize] = source[i];
    }
    destination[i + destSize] = '\0';
    
    return destination;
}