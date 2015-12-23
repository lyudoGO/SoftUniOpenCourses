/* 
 * Write a program that takes any file and slices it to n parts. 
 * The input file names, destination directory and parts should be passed to 
 * the program as arguments. The program should produce proper error messages 
 * in case of errors. Use buffered reading.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#define BUFFER_SIZE 4096

void die(const char *message);
void slice(const char *sourceFile, const char *destinationDirectory, size_t parts);
void assemble(char **partsArr, const char *destinationDirectory, size_t parts);
char **get_parts(const char *destinationDirectory, size_t parts);

int main(int argc, char** argv) 
{
    if (argc < 4)
    {
        die("Usage: ./prog <src-file-name> <dest-directory> <parts>");
    }
    const char *srcFile = argv[1];
    const char *destDir = argv[2];
    const size_t parts = atoi(argv[3]);
    
    slice(srcFile, destDir, parts);
    printf("Parts created!\n");
    
    char **partsArr = get_parts(destDir, parts);
    assemble(partsArr, destDir, parts);
    printf("Parts assembled!\n");
    
    free(partsArr);
    
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

void slice(const char *sourceFile, const char *destinationDirectory, size_t parts)
{
    FILE *file = fopen(sourceFile, "r");
    if (!file) 
    {
        die("Cannot open file");
    } 
    
    fseek(file, 0, SEEK_END);
    long long position = ftell(file);
    fseek(file, 0, SEEK_SET);
    
    long long partSize = (position / parts) + 1;
    char buffer[BUFFER_SIZE];
    size_t i, dirLen = strlen(destinationDirectory);
    for (i = 0; i < parts; i++)
    {
        char name[dirLen + 11];
        sprintf(name, "%s/Part-%lu.jpg", destinationDirectory, i + 1);
        
        FILE *currentDestFile = fopen(name, "w");
        if (!currentDestFile)
            die("Could not create a part");
        
        size_t writtenBytes = 0;
        while (writtenBytes <= partSize && !feof(file))
        {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, file);
            fwrite(buffer, 1, readBytes, currentDestFile);
            writtenBytes += readBytes;
        }
        
        fclose(currentDestFile);
    }
    
    fclose(file);    
}

void assemble(char **partsArr, const char *destinationDirectory, size_t parts)
{
    size_t dirLen = strlen(destinationDirectory);
    char nameDir[dirLen + 20];
    sprintf(nameDir, "%s/assembled-file.jpg", destinationDirectory);
    FILE *resultFile = fopen(nameDir, "w");
    if (!resultFile)
        die(NULL);
    
    char buffer[BUFFER_SIZE];
    size_t i;
    for (i = 0; i < parts; i++)
    {
        FILE *currentPart = fopen(partsArr[i], "r");
        if (!currentPart)
            die(NULL);
        
        while (!(feof(currentPart) || ferror(resultFile) || ferror(currentPart)))
        {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, currentPart);
            fwrite(buffer, 1, readBytes, resultFile);
        }
        
        fclose(currentPart);
    }
    
    fclose(resultFile);    
}

char **get_parts(const char *destinationDirectory, size_t parts)
{
    char **partsArr = calloc(parts, sizeof(char *));
    if (!partsArr) 
    {
        die("No enough memory");
    }
    size_t i;
    for (i = 0; i < parts; i++) 
    {
        size_t dirLen = strlen(destinationDirectory);
        partsArr[i] = calloc(dirLen + 11, sizeof(char));
        sprintf(partsArr[i], "%s/Part-%lu.jpg", destinationDirectory, i + 1);
    }
    return partsArr;
}