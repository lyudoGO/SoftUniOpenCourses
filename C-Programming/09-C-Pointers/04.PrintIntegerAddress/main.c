/* 
 * Write a function which takes as input an integer and prints the address 
 * of it in the memory.
 * Try printing the address of the integer in the function and in the 
 * main function. What is the difference and why?
 */
#include <stdio.h>
#include <stdlib.h>

void print_address(int number);

int main(int argc, char** argv)
{
    int number;
    printf("Please, enter a integer: ");
    scanf("%d", &number);
    
    printf("Inside main: %p\n", &number);
    print_address(&number);
    
    return (0);
}

void print_address(int number)
{
    printf("Inside function: %p", &number);
}