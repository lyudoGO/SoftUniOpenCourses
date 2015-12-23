/* 
 * Write a program that takes as arguments input subtitles file and offset in 
 * milliseconds. The program should edit the subtitles timing by the given 
 * offset. The program should correctly modify seconds, minutes and hours when 
 * overflow occurs (i.e. 61 seconds is not valid). Example: 00:00:52,580 + 700
 *  -> 00:00:53,280. The program should support modifying subtitles in the range 
 * [00:00:00,000 - 99:59:59,999].
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>

void die(const char *message);
int isLineTime(char *line);
void update_subtitle_time(char *time, int offset);

int main(int argc, char** argv) 
{
    int offset;
    printf("Please, enter milliseconds to add: ");
    scanf("%d", &offset);
    
    FILE *sourceFile = fopen("source.sub", "r");
    if (!sourceFile) 
    {
        die(NULL);
    }

    FILE *destFile = fopen("fixed.sub", "w");
    if (!destFile) 
    {
        die(NULL);
    }

    char *line = NULL;
    size_t size = 0;
    while (!feof(sourceFile) && !ferror(sourceFile) && !ferror(destFile)) 
    {
        size_t length = getline(&line, &size, sourceFile);
        if (isLineTime(line))
        {
            char *startTime = strtok(line, "-->");
            char *endTime = strtok(NULL, "-->");
            int timeLen = strlen(startTime);
            update_subtitle_time(startTime, offset);
            update_subtitle_time(endTime, offset);
            char *newLine[length];
            sprintf(newLine, "%s --> %s\n", startTime, endTime);
            fprintf(destFile, "%s", newLine);
        }
        else
        {
            fprintf(destFile, "%s", line);
        }
    }
    free(line);
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

int isLineTime(char *line)
{
    char *string = strstr(line, "-->");
    if (string) 
    {
        return 1;
    }
    return 0;
}

void update_subtitle_time(char *time, int offset)
{
   char *ptr, *token = strtok(time, ":,");
   long int hours = strtol(token, &ptr, 10);
   long int minutes = strtol(strtok(NULL, ":,"), &ptr, 10);
   long int seconds = strtol(strtok(NULL, ":,"), &ptr, 10);
   long int milliseconds = strtol(strtok(NULL, ":,"), &ptr, 10);
  
   milliseconds += offset;
   seconds += milliseconds / 1000;
   minutes += seconds / 60;
   hours += minutes / 60;
   
   milliseconds %= 1000;
   seconds %= 60;
   minutes %= 60;
   sprintf(time, "%02ld:%02ld:%02ld,%03ld", hours, minutes, seconds, milliseconds);
}