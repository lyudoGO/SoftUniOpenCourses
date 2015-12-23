#include <stdio.h>

int main()
{
    int num, row, col;
    printf("Please, enter a integer in range [1..20]: ");
    scanf("%d", &num);
    for (row = 1; row <= num; row++)
    {
        int temp = row;
        for (col = 1; col <= num; col++)
        {
            printf("%d ", temp);
            temp++;
        }
        printf("\n");
    }

    return 0;
}
