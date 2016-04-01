#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int is_inside_board(double boardX, double boardY, double boardR, double shotX, double shotY);
int is_inside_head(double headX, double headY, double headR, double shotX, double shotY);
int is_inside_arm(double topLX, double topLY, double bottomRX, double bottomRY, double shotX, double shotY);

int main(int argc, char** argv) 
{
    double boardX, boardY, boardR;
    double headX, headY, headR;
    double topLX, topLY, bottomRX, bottomRY;
    double shotX, shotY;
    int n, totalPoints = 0, health = 100, boardHits = 0, totalShots = 0;
    
    scanf("%lf%lf%lf", &boardX, &boardY, &boardR);
    scanf("%lf%lf%lf", &headX, &headY, &headR);
    scanf("%lf%lf%lf%lf", &topLX, &topLY, &bottomRX, &bottomRY);
    scanf("%d", &n);
    int i;
    for (i = 0; i < n; i++) 
    {
        scanf("%lf%lf", &shotX, &shotY);
        totalShots++;
        if (is_inside_board(boardX, boardY, boardR, shotX, shotY)) 
        {
            if (is_inside_head(headX, headY, headR, shotX, shotY) ||
                is_inside_arm(topLX, topLY, bottomRX, bottomRY, shotX, shotY)) {
                totalPoints += 25;
            } else {
                totalPoints += 50;
            }
            boardHits++;
        }
        if (is_inside_arm(topLX, topLY, bottomRX, bottomRY, shotX, shotY)) 
        {
            health -= 30;
            if (health <= 0)
            {
                health = 0;
                break;
            }
        }
        if (is_inside_head(headX, headY, headR, shotX, shotY)) 
        {
            health -= 25;
            if (health <= 0)
            {
                health = 0;
                break;
            }
        }
    }

    printf("Points: %d\n", totalPoints);
    printf("Hit ratio: %.f%%\n", floor((boardHits / (float)totalShots) * 100));
    printf("Bay Mile: %d\n", health);

    return (EXIT_SUCCESS);
}

int is_inside_board(double boardX, double boardY, double boardR, double shotX, double shotY)
{
    return sqrt(pow((shotX - boardX), 2) + pow((shotY - boardY), 2)) <= boardR;
}

int is_inside_head(double headX, double headY, double headR, double shotX, double shotY)
{
    return sqrt(pow((shotX - headX), 2) + pow((shotY - headY), 2)) <= headR;
}

int is_inside_arm(double topLX, double topLY, double bottomRX, double bottomRY, double shotX, double shotY)
{
    return shotX >= topLX && shotX <= bottomRX && shotY <= topLY && shotY >= bottomRY;
}