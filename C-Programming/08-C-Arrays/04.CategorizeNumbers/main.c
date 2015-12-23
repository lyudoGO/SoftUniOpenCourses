#include <stdio.h>
#include <math.h>
#include <float.h>

void print_numbers(double numbers[], int size);
void calculate_numbers(double numbers[], int size, double*, double*, 
        double*, double*);

int main(int argc, char** argv) {
    int count;
    printf("Please, enter count of numbers: ");
    scanf("%d", &count);

    double roundNumbers[count], floatNumbers[count];
    int i, indexR = 0, indexF = 0;
    for (i = 0; i < count; i++) {
        double tempNum, remainder;
        scanf("%lf", &tempNum);
        remainder = fmod(tempNum, 1);
        if (remainder == 0) {
            roundNumbers[indexR++] = tempNum;
        } else {
            floatNumbers[indexF++] = tempNum;
        }
    }
    
    double minR = DBL_MAX, maxR = DBL_MIN, sumR = 0, avgR = 0; 
    double minF = DBL_MAX, maxF = DBL_MIN, sumF = 0, avgF = 0; 
    calculate_numbers(roundNumbers, indexR, &minR, &maxR, &sumR, &avgR);
    calculate_numbers(floatNumbers, indexF, &minF, &maxF, &sumF, &avgF);
    
    print_numbers(roundNumbers, indexR);
    printf(" -> min: %.2f;max: %.2f;sum: %.2f;avg: %.2f\n", minR, maxR, sumR, avgR);
    print_numbers(floatNumbers, indexF);
    printf(" -> min: %.2f;max: %.2f;sum: %.2f;avg: %.2f\n", minF, maxF, sumF, avgF);
    
    return (0);
}

void calculate_numbers(double numbers[], int size, double *min, double *max, 
        double *sum, double *avg) {
    int i;
    for (i = 0; i < size; i++) {
        (*sum) += numbers[i];
        if (numbers[i] < *min) {
            (*min) = numbers[i];
        }
        if (numbers[i] > *max) {
            (*max) = numbers[i];
        }
    }
    (*avg) = (*sum) / (double)size;  
}

void print_numbers(double numbers[], int size) {
    int i;
    printf("[");
    for (i = 0; i < size; i++) {
        if (i == size - 1) {
            printf("%.2f]", numbers[i]);
        } else {
            printf("%.2f, ", numbers[i]);
        }
    }
}