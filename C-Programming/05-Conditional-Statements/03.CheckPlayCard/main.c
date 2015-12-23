#include <stdio.h>
#include <string.h>

int main()
{
    char *cards[] = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    char card[3];
    printf("Please, enter card: ");
    int machtes = scanf("%2s", card);
    if (machtes == 0)
    {
        printf("Invalid input format.\n");
        return 1;
    }

    if (isValidCard(card, cards))
    {
        printf("%s", "yes");
    }
    else
    {
        printf("%s", "no");
    }

    return 0;
}

int isValidCard(char card[3], char *cards[])
{
    int i;
    for (i = 0; i < 13; i++)
    {
        int comp = strcmp(card, cards[i]);
        if (comp == 0)
        {
            return 1;
        }
    }

    return 0;
}
