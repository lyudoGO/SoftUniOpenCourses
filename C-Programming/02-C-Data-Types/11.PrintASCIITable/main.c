#include <stdio.h>

int main()
{
    int i;
    for (i = 0; i < 256; i++) {
        printf("Character: %c => ASCII: %d\n", i, i);
    }

    return 0;
}
