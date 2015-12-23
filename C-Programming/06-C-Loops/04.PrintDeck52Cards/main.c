#include <stdio.h>
#include <string.h>

int main()
{
    int row, col;
    char *cardNumber[3];
    char cardFace;

    for (row = 1; row <= 13; row++)
    {
        switch (row)
        {
            case 1: cardNumber[0] = '2'; break;
            case 2: cardNumber[0] = '3'; break;
            case 3: cardNumber[0] = '4'; break;
            case 4: cardNumber[0] = '5'; break;
            case 5: cardNumber[0] = '6'; break;
            case 6: cardNumber[0] = '7'; break;
            case 7: cardNumber[0] = '8'; break;
            case 8: cardNumber[0] = '9'; break;
            case 9: strcpy(cardNumber, "10");break;
            case 10: cardNumber[0] = 'J'; break;
            case 11: cardNumber[0] = 'Q'; break;
            case 12: cardNumber[0] = 'K'; break;
            case 13: cardNumber[0] = 'A'; break;
            default: break;
        }
        for (col = 1; col <= 4; col++)
        {
            switch (col)
            {
                case 1: cardFace = 'C'; break;
                case 2: cardFace = 'D'; break;
                case 3: cardFace = 'H'; break;
                case 4: cardFace = 'S'; break;
                default: break;
            }
            printf("%2s%c ", cardNumber, cardFace);
        }
        printf("\n");
    }

    return 0;
}
