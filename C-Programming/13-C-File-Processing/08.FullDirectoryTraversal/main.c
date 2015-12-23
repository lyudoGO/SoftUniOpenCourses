/* 
 * Modify your previous program to recursively traverse the sub-directories of 
 * the starting directory as well.
 */
#include <stdio.h>
#include <stdlib.h>
#include <dirent.h>
#include <errno.h>
#include <string.h>
#include <math.h>
#define PATH_LENGTH 256

void directory_traversal(FILE *destFile, char *path);
void die(const char *message);

int main(int argc, char** argv) 
{
    char path[PATH_LENGTH];
    printf("Please, enter path to traverse: ");
    scanf("%s", path);

    FILE *destFile = fopen("report.txt", "w");
    if (!destFile)
        die(NULL);
    
    directory_traversal(destFile, path);
    
    fclose(destFile);
    printf("Job done in report.txt!");
    return (EXIT_SUCCESS);
}

void directory_traversal(FILE *destFile, char *path)
{
    DIR *directory;
    struct dirent *entry;
    directory = opendir(path);
    if (!directory)
        return;
     
    if (entry == NULL) 
        return;

    while ((entry = readdir(directory)) != NULL) 
    {
        if (strcmp(entry->d_name, ".") == 0 || strcmp(entry->d_name, "..") == 0)
            continue;

        if (entry->d_type == DT_DIR)
        {
            char currentPath[256];
            sprintf(currentPath, "%s/%s", path, entry->d_name);
            directory_traversal(destFile, currentPath);
        }
 
        char filePath[PATH_LENGTH];
        sprintf(filePath, "%s/%s", path, entry->d_name);
        FILE *file = fopen(filePath, "r");
        if (!file)
            die(NULL);

        fseek(file, 0L, SEEK_END);
        size_t fileSize = ftell(file);
        fprintf(destFile, "%s - %.lfKB\n", filePath, ceil((double)fileSize/1024));
        fclose(file); 
    }
    closedir(directory);
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