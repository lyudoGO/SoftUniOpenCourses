#include <stdio.h>

//void PrintMatrix(int matrix[5][5], int num)
//{
//    int row, col;
//    for (row = 0; row < num; row++)
//    {
//        for (col = 0; col < num; col++)
//        {
//            printf("%d ", matrix[row][col]);
//        }
//        printf("\n");
//    }
//}

int main()
{
    int num, stop, i;
    int row = 0, col = 0;
    char direction = 'R';
    printf("Please, enter a integer: ");
    scanf("%d", &num);

    int matrix[num][num];
    stop = num * num;

    for (i = 1; i <= stop; i++)
    {
        if ((direction == 'R') && (col > num - 1))
        {
            direction = 'D';
            col--;
            row++;
        }
        if ((direction == 'D') && (row > num - 1))
        {
            direction = 'L';
            col--;
            row--;
        }
        if ((direction == 'L') && (col < 0))
        {
            direction = 'U';
            row++;
            col--;
        }
        if ((direction == 'U'))
        {
            row--;
        }

        matrix[row][col] = i;
        if ((direction == 'R'))
        {
            col++;
        }
        if ((direction == 'D'))
        {
            row++;
        }
        if ((direction == 'L'))
        {
            col--;
        }
    }

        int rowM, colM;
        for (rowM = 0; rowM < num; rowM++)
        {
            for (colM = 0; colM < num; colM++)
            {
                printf("%d ", matrix[rowM][colM]);
            }
            printf("\n");
        }

    return 0;
}
