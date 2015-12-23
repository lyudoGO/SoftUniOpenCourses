/* 
 * Write a program that copies the contents of a binary file
 * (e.g. image, video, etc.) to another file.
 */
#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#define BUFFER_SIZE 4096

void die(const char*);

int main(int argc, char** argv) 
{
    FILE *sourceFile = fopen("ferrari.jpg", "r");
    if (!sourceFile) 
    {
        die("Cannot open file");
    }
    
    FILE *destFile = fopen("copied-ferrari.jpg", "w");
    if (!destFile) 
    {
        die("Cannot open file");
    }

    char buffer[BUFFER_SIZE];
    while (!feof(sourceFile) && !ferror(sourceFile) && !ferror(destFile)) 
    {
        size_t readSize = fread(buffer, 1, BUFFER_SIZE, sourceFile);
        fwrite(buffer, 1, readSize, destFile);
    }
    
    fclose(sourceFile);
    fclose(destFile);
    
    return (EXIT_SUCCESS);
}

void die(const char *message)
{
    if (errno) 
    {
        perror(message);
    }
    else 
    {
        fprintf(stderr, "%s\n", message);
    }
    exit(1);
}