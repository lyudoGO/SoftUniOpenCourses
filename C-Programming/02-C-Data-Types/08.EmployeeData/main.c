#include <stdio.h>

int main()
{
    char firstName[5] = "Ivan";
    char lastName[7] = "Ivanov";
    int age = 30;
    char gender = 'm';
    char personalId[12] = "8306112507";
    int employeeNumber = 27560000;

    printf("First name: %s\nLast name: %s\n", firstName, lastName);
    printf("Age: %d\nGender: %c\n", age, gender);
    printf("Personal ID: %s\nUnique Employee number: %d\n", personalId, employeeNumber);
    return 0;
}
