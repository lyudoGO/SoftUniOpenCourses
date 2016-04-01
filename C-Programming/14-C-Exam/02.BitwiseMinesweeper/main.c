#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void move_right(int *number, int position);
void move_left(int *number, int position);
void move_up(int *number, int *secondNum, int position);
void move_down(int *number, int *secondNum, int position);
void set_bit_to_one(int *number, int position);
void set_bit_to_zero(int *number, int position);
int is_bit_one(int number, int position);

int main(int argc, char** argv) 
{
    int n, isSolve = 1;
    scanf("%d", &n);
    int numbers[n];
    int i;
    for (i = 0; i < n; i++) 
    {
        scanf("%d", &numbers[i]);
    }

    char command[6];
    scanf("%s", command);
    int startRow = 0, currentCol = 0;
    while (strcmp(command, "end") != 0) 
    {
        if (strcmp(command, "right") == 0) 
        {
            int currentPos = currentCol - 1;
            if (currentPos < 0) {
                currentPos = 31;
            }
            if (is_bit_one(numbers[startRow], currentPos))
            {
                printf("GAME OVER. Stepped a mine at %d %d", startRow, currentPos);
                isSolve = 1;
                break;
            }
            else
            {
                move_right(&numbers[startRow], currentCol);
                currentCol = currentPos;
            }
        }
        if (strcmp(command, "left") == 0) 
        {
            int currentPos = currentCol + 1;
            if (currentPos > 31) {
                currentPos = 0;
            }
            if (is_bit_one(numbers[startRow], currentPos))
            {
                printf("GAME OVER. Stepped a mine at %d %d", startRow, currentPos);
                isSolve = 0;
                break;
            }
            else
            {
                move_left(&numbers[startRow], currentCol);
                currentCol = currentPos;
            }
        }
        if (strcmp(command, "up") == 0) 
        {
            int currentRow = startRow - 1;
            if (currentRow < 0) {
                currentRow = n - 1;
            }
            if (is_bit_one(numbers[currentRow], currentCol))
            {
                printf("GAME OVER. Stepped a mine at %d %d", currentRow, currentCol);
                isSolve = 1;
                break;
            }
            else
            {
                move_up(&numbers[startRow], &numbers[currentRow], currentCol);
                startRow = currentRow;
            }            
        }
        if (strcmp(command, "down") == 0) 
        {
            int currentRow = startRow + 1;
            if (currentRow > n) {
                currentRow = 0;
            }
            if (is_bit_one(numbers[currentRow], currentCol))
            {
                printf("GAME OVER. Stepped a mine at %d %d", currentRow, currentCol);
                isSolve = 1;
                break;
            }
            else
            {
                move_up(&numbers[startRow], &numbers[currentRow], currentCol);
                startRow = currentRow;
            }  
        }

        scanf("%s", command);
    }
    printf("\n");
    int j;
    for (j = 0; j < n; j++) {
        printf("%d\n", numbers[i]);
    }

    return (EXIT_SUCCESS);
}

void move_up(int *number, int *secondNum, int position)
{
    set_bit_to_zero(&number, position);
    set_bit_to_one(&secondNum, position);
}

void move_down(int *number, int *secondNum, int position)
{
    set_bit_to_zero(number, position);
    set_bit_to_one(secondNum, position);
}

void move_right(int *number, int position)
{
    if (position == 0) 
    {
        set_bit_to_zero(&number, position);
        set_bit_to_one(&number, 31);
    }
    else 
    {
        set_bit_to_zero(&number, position);
        set_bit_to_one(&number, position - 1);
    }
}

void move_left(int *number, int position)
{
    if (position == 31) 
    {
        set_bit_to_zero(&number, position);
        set_bit_to_one(&number, 0);
    }
    else 
    {
        set_bit_to_zero(&number, position);
        set_bit_to_one(&number, position + 1);
    }
}

void set_bit_to_one(int *number, int position)
{
    *number = *number | (1 << position);
}

void set_bit_to_zero(int *number, int position)
{
    *number = *number & ~(1 << position);
}

int is_bit_one(int number, int position)
{
    int bitAtPosition = (number >> position) & 1;
    return bitAtPosition;
}