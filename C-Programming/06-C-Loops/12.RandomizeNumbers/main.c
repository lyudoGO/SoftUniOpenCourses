#include <stdio.h>

int main()
{
    int num, i;
    printf("Please, enter a integer: ");
    scanf("%d", &num);
    int numbers[num];

    for (i = 0; i < num; i++)
    {
        numbers[i] = i + 1;
    }

    for (i = 0; i < num; i++)
    {
        int randNum = rand() % num;
        int temp = numbers[randNum];
        numbers[randNum] = numbers[0];
        numbers[0] = temp;
    }

    for (i = 0; i < num; i++)
    {
        printf("%d ", numbers[i]);
    }
    printf("\n");
    return 0;
}
