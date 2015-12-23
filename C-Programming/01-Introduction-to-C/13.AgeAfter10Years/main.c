#include <stdio.h>
#include <time.h>

int main()
{
    time_t timeNow = time(NULL);
    struct tm birthDay = {};
    double seconds;
    int day, month, year;

    printf("Please, enter birhtday in format DD.MM.YYYY: ");
    scanf("%d.%d.%d", &day, &month, &year);

    birthDay.tm_mday = day;
    birthDay.tm_mon = month;
    birthDay.tm_year = year - 1900;

    seconds = difftime(timeNow, mktime(&birthDay));
    double years = seconds / (86400 * 365);

    printf("Now: %.f\n", years);
    printf("After 10 years: %.f\n", years + 10);

    return 0;
}
