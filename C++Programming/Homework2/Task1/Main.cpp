// 1. Write a class called “Building”.Write constructors, destructor, attributes and
//  functions for the class.
// 2. Use that class in a program where you must define business park that consist of 3
//  buildings.The first one is for company called “XYZ industries”, has 6 floors, 127
//  offices, 600 employees and 196 free working seats.The second one is for building
//  called “Rapid Development Crew”, has 8 floors, 210 offices, 822 employees, 85 free
//  working seats and on the first floor there is a restaurant instead of offices.The third
//  building if for “SoftUni”.To fit SoftUni’s needs the build has 11 floors, 106 offices,
//  200 employees and 60 free working seats.
// Based on that information make a program to print the names of the buildings with :
//	-Most employees
//	- Most free places
//	- Highest coefficient employees / (employees + free seats)
//	- Most people per floor
//	- Least people per floor
//	- Most offices per floor
//	- Least offices per floor
//	- Most people per office
//	- Least people per office
// Note : Make three different objects for the three buildings and put them in an array
// called “businessPark”.

#include <string>
#include <algorithm>
#include "Building.h"
using namespace std;

string getMostEmployees(Building* businessPark, size_t lenght);
string getMostFreePlaces(Building* businessPark, size_t lenght);
string getHighestCoefficient(Building* businessPark, size_t lenght);

int main()
{
	Building firstBuilding = Building(6, 127, 0, 600, 196, "XYZ industries");
	Building secondBuilding = Building(8, 210, 1, 822, 85, "Rapid Development Crew");
	Building thirthBuilding = Building(11, 106, 0, 200, 60, "SoftUni");

	Building businessPark[] = { firstBuilding, secondBuilding, thirthBuilding };
	
	cout << "Building with most employees: " << getMostEmployees(businessPark, 3) << endl;
	cout << "Building with most free places: " << getMostFreePlaces(businessPark, 3) << endl;
	cout << "Building withh highest coefficient employees: " << getHighestCoefficient(businessPark, 3) << endl;

	sort(businessPark, businessPark + 3, [](Building &a, Building &b){
		return a.peoplePerFloor() > b.peoplePerFloor();
	});

	cout << "Building with most people per floor: " << businessPark[0].getName() << endl;
	cout << "Building with least people per floor: " << businessPark[2].getName() << endl;

	sort(businessPark, businessPark + 3, [](Building &a, Building &b) {
		return a.officesPerFloor() > b.officesPerFloor();
	});

	cout << "Building with most offices per floor: " << businessPark[0].getName() << endl;
	cout << "Building with least offices per floor: " << businessPark[2].getName() << endl;

	sort(businessPark, businessPark + 3, [](Building &a, Building &b) {
		return a.peoplePerOffice() > b.peoplePerOffice();
	});

	cout << "Building with most people per office: " << businessPark[0].getName() << endl;
	cout << "Building with least people per office: " << businessPark[2].getName() << endl;

	return 0;
}

string getMostEmployees(Building* businessPark, size_t lenght)
{
	string name = "";
	int maxEmployees = INT_MIN;
	for (size_t i = 0; i < lenght; i++)
	{
		if (businessPark[i].getEmployees() > maxEmployees)
		{
			maxEmployees = businessPark[i].getEmployees();
			name = businessPark[i].getName();
		}
	}

	return name;
}

string getMostFreePlaces(Building* businessPark, size_t lenght)
{
	string name = "";
	int maxPlaces = 0;
	for (size_t i = 0; i < lenght; i++)
	{
		if (businessPark[i].getWorkingSeats() > maxPlaces)
		{
			maxPlaces = businessPark[i].getWorkingSeats();
			name = businessPark[i].getName();
		}
	}

	return name;
}

string getHighestCoefficient(Building* businessPark, size_t lenght)
{
	string name = "";
	float maxCoeff = 0;
	for (size_t i = 0; i < lenght; i++)
	{
		if (businessPark[i].getCoefficient() > maxCoeff)
		{
			maxCoeff = businessPark[i].getCoefficient();
			name = businessPark[i].getName();
		}
	}

	return name;
}