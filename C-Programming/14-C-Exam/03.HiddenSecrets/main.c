#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>
#define BLOCK_SIZE 64

void die(const char *message);
int get_sum_last_bytes(const char *buffer);
void process_file(FILE *firstFile, FILE *destFile);

static char firstFName[12];
static char secondFName[12];
static char tirthFName[12];
static char dstFileName[12];
    
int main(int argc, char** argv) 
{
    if (argc == 3) 
    {
        strcpy(firstFName, argv[1]);
        strcpy(secondFName,argv[2]);
        strcpy(dstFileName,"merged.txt");
    }
    else if (argc == 4)
    {
        strcpy(firstFName, argv[1]);
        strcpy(secondFName, argv[2]);
        strcpy(tirthFName, argv[3]);
        strcpy(dstFileName, "merged.jpeg");        
    }
    else
    {
        die("Usage: [<src-file-1> <src-file-2> …]");
    }

    FILE *destFile = fopen(dstFileName, "a");
    if (!destFile)
        die(dstFileName);
    
    FILE *firstFile = fopen(firstFName, "r");
    if (!firstFile)
        die(firstFName);
    FILE *secondFile = fopen(secondFName, "r");
    if (!secondFile)
        die(secondFName);

    process_file(firstFile, destFile);
    process_file(secondFile, destFile); 
    
    if (argc == 4)
    {
        FILE *tirthFile = fopen(tirthFName, "r");
        if (!tirthFile)
           die(tirthFName);  
        process_file(tirthFile, destFile);
        fclose(tirthFile);
    }
    
    fclose(destFile);
    fclose(firstFile);
    fclose(secondFile);

    printf("Eureka!");    
    return (EXIT_SUCCESS);
}

void process_file(FILE *file, FILE *destFile)
{
    char buffer[BLOCK_SIZE];
    while (!feof(file) && !ferror(file) && !ferror(destFile)) 
    {
        size_t readSize = fread(buffer, 1, BLOCK_SIZE, file);
        char lastBytes[4];
        size_t lastBSize = (readSize - 4);
        memcpy(lastBytes, buffer + lastBSize, 4);
        int sum = get_sum_last_bytes(lastBytes);
        if (sum == 210) 
        {
            size_t fullSize = (readSize - 4);
            fwrite(buffer, 1, fullSize, destFile);
        }
        if (sum == 138) 
        {
            size_t halfSize = (readSize - 4) / 2;
            fwrite(buffer, 1, halfSize, destFile);
        }
        if (sum == 178) 
        {
            continue;
        }
    }    
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

int get_sum_last_bytes(const char *buffer)
{
    int i, sum = 0;
    for (i = 0; i < 4; i++) 
    {
        sum += buffer[i];
    }
    return sum;
}