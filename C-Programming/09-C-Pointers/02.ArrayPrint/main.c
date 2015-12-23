/* 
 * Declare an array of integers and print it on the console. 
 * Do NOT use the indexer operator [].
 */
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{

    int array[] = {12, 0, -45, 3434, -67 };
    int size = sizeof(array) / sizeof(int);
    int i;
    for (i = 0; i < size; i++) {
        printf("%d ", *(array + i));
    }

    return (0);
}