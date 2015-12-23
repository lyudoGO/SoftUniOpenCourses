/* 
 * Write a function that declares and initializes and integer on the stack, 
 * then returning it. Try creating the function with two different declarations:
 * int new_integer()
 * int* new_integer_ptr()
 */
#include <stdio.h>
#include <stdlib.h>

int new_integer();
int* new_integer_ptr();

int main(int argc, char** argv) 
{
    int newInteger = new_integer();
    int *newIntgerPtr = new_integer_ptr();
    
    printf("Integer 100 = %d\n", newInteger);
    printf("Integer ptr 101 = %d\n", newIntgerPtr);
    
    return (0);
}

int new_integer()
{
    // return a copy of variable
    // then num is dead
    // safe
    int num = 100;
    return num;
}

int* new_integer_ptr()
{
    // return pointer to variable
    // then num is dead and pointer is set to garbage
    // unsafe
    int num = 101;
    return &num;
}