// Make a program that reads line from the keyboard and checks how many upper and lower case 
// letters and other characters are available in the string.
#include <string>
#include <iostream>

using namespace std;

int main()
{
	string line;
	unsigned int lower = 0, upper = 0, other = 0;

	cout << "Please, enter a text: " << endl;
	getline(cin, line);

	for (size_t i = 0; i < line.length(); i++)
	{
		if (islower(line[i]))
		{
			lower++;
		}
		else if (isupper(line[i]))
		{
			upper++;
		}
		else
		{
			other++;
		}
	}

	cout << "Lower letters: " << lower << endl;
	cout << "Upper letters: " << upper << endl;
	cout << "Other: " << other << endl;

	getchar();

	return 0;
}