/* 
 * Declare a struct called Client with the following members: name, age and 
 * account balance. Write a function that sorts an array of clients using a 
 * specific comparator. The comparator should be another function that 
 * determines how the clients are sorted. Write comparators for sorting the
 * clients by name, age and account balance.
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define COUNT 3

typedef struct Client
{
    char *name;
    double balance;
    short age;
}Client;

void sort_clients(Client *clients, int count, int (*compare)(Client*, Client*));
int name_comparator(Client*, Client*);
int age_comparator(Client*, Client*);
int balance_comparator(Client*, Client*);
void print_clients(Client*, int count);

int main(int argc, char** argv) 
{
    struct Client clients[] = 
    {
        { "Ivan Ivanov", 1200.50, 35 },
        { "Silva Petkova", 2350.00, 30 },
        { "Kiro Karburatora", 1560.10, 40 }
    };
    
    sort_clients(clients, COUNT, &name_comparator);
    printf("\nSorted by name:\n");
    print_clients(clients, COUNT);
   
    sort_clients(clients, COUNT, &age_comparator);
    printf("\nSorted by age:\n");
    print_clients(clients, COUNT);
    
    sort_clients(clients, COUNT, &balance_comparator);
    printf("\nSorted by balance:\n");
    print_clients(clients, COUNT);
    
    return (0);
}

void sort_clients(Client *clients, int count, 
        int (*compare)(Client *first, Client *second))
{
    int isSwapped = 1;
    while (isSwapped) 
    {
        isSwapped = 0;
        int i;
        for (i = 0; i < count - 1; i++) 
        {
            if (compare(clients + i, clients + (i + 1)) > 0) 
            {
                Client temp = clients[i];
                clients[i] = clients[i + 1];
                clients[i + 1] = temp;
                isSwapped = 1;
            }
        }
    }
}

int name_comparator(Client *first, Client *second)
{
    return strcmp(first->name, second->name);
}

int age_comparator(Client *first, Client *second)
{
    return (first->age - second->age);
}

int balance_comparator(Client *first, Client *second)
{
    if (first->balance > second->balance) 
    {
        return 1;
    }
    if (first->balance < second->balance) 
    {
        return -1;
    }
    return 0;
}

void print_clients(Client *clients, int count)
{
    int i;
    for (i = 0; i < count; i++) {
        printf("Name: %s; Age: %hu; Balance: %.2lf\n", (clients + i)->name,
                (clients + i)->age, (clients + i)->balance);
    }
}