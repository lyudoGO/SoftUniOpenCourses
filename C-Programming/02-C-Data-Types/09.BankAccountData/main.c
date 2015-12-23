#include <stdio.h>

int main()
{
    char firstName[5] = "Ivan";
    char middleName[7] = "Petrov";
    char lastName[7] = "Ivanov";
    double balance = 1200.55;
    char bankName[20] = "Antinari Bank";
    char iban[15] = "BG8306112507";
    char firstCard[20] = "1111-0000-2222-3333";
    char secondCard[20] = "2323-0000-2222-7890";
    char thirdCard[20] = "4545-0000-5555-3333";

    printf("First name: %s\nMiddle name: %s\nLast name: %s\n", firstName, middleName, lastName);
    printf("Balance: %.2f Lv.\nBank name: %s\n", balance, bankName);
    printf("IBAN: %s\nFirst card number: %s\n", iban, firstCard);
    printf("Second card number: %s\nThird card number: %s\n", secondCard, thirdCard);
    return 0;
}
