#include <stdio.h>
#include <time.h>

int main()
{
    time_t timeNow = time(NULL);
    struct tm *dateAndTime;
    char parsedTime[40];

    dateAndTime = localtime(&timeNow);

    strftime(parsedTime, 40, "%d %B %Y %H:%M:%S", dateAndTime);
    printf("%s\n", parsedTime);

    return 0;
}
