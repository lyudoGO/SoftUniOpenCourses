#include <stdio.h>
#include <stdlib.h>

int main()
{
    int numberN;
    printf("Please, enter a integer number N: ");
    scanf("%d", &numberN);

    int i;
    for (i = 2; i <= numberN + 1; i++) {
        if (i % 2 == 0) {
            printf("%d ", i);
        }
        else {
            printf("%d ", -i);
        }
    }

    return 0;
}
