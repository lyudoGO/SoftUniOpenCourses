#include <stdio.h>

unsigned long long catalanDP(unsigned int num)
{
    unsigned long long catalan[num + 1];
    int i, j;
    catalan[0] = catalan[1] = 1;

    for (i = 2; i <= num; i++)
    {
        catalan[i] = 0;
        for (j = 0; j < i; j++)
        {
            catalan[i] += catalan[j] * catalan[i - j - 1];
        }
    }

    return catalan[num];
}

int main()
{
    unsigned long long num, catalanN;
    printf("Please, enter a integer int range [1..100]: ");
    scanf("%llu", &num);

    catalanN = catalanDP(num);
    printf("%llu", catalanN);
    return 0;
}
