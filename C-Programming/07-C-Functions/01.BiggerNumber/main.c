#include <stdio.h>
#include <stdlib.h>

int get_max(int numberOne, int numberTwo);

int main(int argc, char** argv) {

    int numA, numB;
    printf("Please, enter two integers: ");
    scanf("%d%d", &numA, &numB);
    
    printf("Biggest: %d\n", get_max(numA, numB));
    return (0);
}

int get_max(int numberOne, int numberTwo) {
    if (numberOne > numberTwo) {
        return numberOne;
    } else {
        return numberTwo;
    }
}
