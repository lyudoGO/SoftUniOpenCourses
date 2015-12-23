/* 
 * Traverse a given directory for all files with the given extension. 
 * Search through the first level of the directory only and write information 
 * about each found file in report.txt.
 */
#include <stdio.h>
#include <stdlib.h>
#include <dirent.h>
#include <errno.h>
#include <string.h>
#include <math.h>
#define PATH_LENGTH 256

void die(const char *message);

int main(int argc, char** argv) 
{
    char path[PATH_LENGTH];
    printf("Please, enter path to traverse: ");
    scanf("%s", path);
    
    DIR *directory;
    struct dirent *entry;
    directory = opendir(path);
    if (!directory)
        die(NULL);

    FILE *destFile = fopen("report.txt", "w");
    if (!destFile)
        die(NULL);
    
    while ((entry = readdir(directory)) != NULL) 
    {
        if (entry->d_type == DT_DIR)
            continue;

        char filePath[PATH_LENGTH];
        sprintf(filePath, "%s/%s", path, entry->d_name);
        FILE *file = fopen(filePath, "r");
        if (!file)
            die(NULL);
        
        fseek(file, 0L, SEEK_END);
        size_t fileSize = ftell(file);
        fprintf(destFile, "\n%s - %.lfKB", entry->d_name, ceil((double)fileSize/1024));
        fclose(file);
    }
    fclose(destFile);
    closedir(directory);

    printf("Job done in report.txt!");
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