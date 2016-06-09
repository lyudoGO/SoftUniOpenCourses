// Make a program that demonstrates all the functions learned in lecture 1.
#include <string>
#include <iostream>

using namespace std;

void printChar(char symbol)
{
	cout << "You entered: ";
	cout << symbol << endl;
}

int sum(int numA, int numB)
{
	return numA + numB;
}

unsigned short checkAge(unsigned short age) 
{
	if (age < 20)
	{
		return 0;
	}
	else if (age < 30)
	{
		return 1;
	}
	else
	{
		return 2;
	}
}

void getString()
{
	string line;
	cout << "Please, enter a string: ";
	getline(cin, line);
	cout << "Your string is: " << line << endl;
}

int main()
{
	char symbol;
	int numA = 0, numB = 0;
	unsigned short age = 0;
	cout << "Please enter a symbol: ";
	cin >> symbol;
	printChar(symbol);

	cout << "Please enter two integers: ";
	cin >> numA;
	cin >> numB;
	cout << "Sum: " << sum(numA, numB) << endl;

	cout << "Please enter your age: ";
	cin >> age;
	cout << checkAge(age) << endl;

	getchar();
	getString();

	getchar();
	return 0;
}