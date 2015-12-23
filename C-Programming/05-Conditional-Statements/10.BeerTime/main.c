#include <stdio.h>
#include <time.h>

time_t toSeconds(int hours, int minutes)
{
    time_t rawTime = time(NULL), seconds;
    struct tm *storageTime;
    storageTime = localtime(&rawTime);
    storageTime->tm_hour = hours;
    storageTime->tm_min = minutes;

    seconds = mktime(storageTime);

    return seconds;
}

int main()
{
    int hours, minutes;
    char designator[3];
    time_t startTime, endTime, beerTime;

    printf("Please, enter time in format hh:mm AM/PM: ");
    int machtes = scanf("%d:%d", &hours, &minutes);
    scanf("%2s", designator);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    if (strcmp(designator, "PM") == 0)
    {
        hours = hours + 12;
    }

    startTime = toSeconds(13, 0);
    endTime = toSeconds(3, 0);
    beerTime = toSeconds(hours, minutes);

    double startSeconds = difftime(beerTime, startTime);
    double endSeconds = difftime(beerTime, endTime);
    if (startSeconds >= 0 || endSeconds < 0)
    {
        printf("beer time");
    }
    else
    {
        printf("non-beer time");
    }

    return 0;
}


