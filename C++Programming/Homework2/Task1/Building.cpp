#include "Building.h"

Building::Building()
{
	floors = 0;
	offices = 0;
	restaurant = 0;
	employees = 0;
	freeWorkingSeats = 0;
	name = "";
}

Building::Building(short newFloors, short newOffices, short newRestaurant)
{
	floors = newFloors;
	offices = newOffices;
	restaurant = newRestaurant;
}

Building::Building(int newEmpoyees, int newWorkingSeats, std::string newName)
{
	employees = newEmpoyees;
	freeWorkingSeats = newWorkingSeats;
	name = newName;
}

Building::Building(short newFloors, short newOffices, short newRestaurant, int newEmpoyees, int newWorkingSeats, std::string newName)
{
	floors = newFloors;
	offices = newOffices;
	restaurant = newRestaurant;
	employees = newEmpoyees;
	freeWorkingSeats = newWorkingSeats;
	name = newName;
}

Building::~Building()
{
}

short Building::getFloors()
{
	return floors;
}

void Building::setFloors(short newFloors)
{
	if (newFloors < 0)
		return;
	floors = newFloors;
}

short Building::getOffices()
{
	return offices;
}

void Building::setOffices(short newOffices)
{
	if (newOffices < 0)
		return;
	offices = newOffices;
}

short Building::getRestaurant()
{
	return restaurant;
}

void Building::setRestaurant(short newRestaurant)
{
	if (newRestaurant < 0)
		return;
	restaurant = newRestaurant;
}

int Building::getEmployees()
{
	return employees;
}

void Building::setEmployees(int newEmployees)
{
	if (newEmployees < 0)
		return;
	employees = newEmployees;
}

int Building::getWorkingSeats()
{
	return freeWorkingSeats;
}

void Building::setWorkingSeats(int newWorkingSeats)
{
	if (newWorkingSeats < 0)
		return;
	freeWorkingSeats = newWorkingSeats;
}

std::string Building::getName()
{
	return name;
}

void Building::setName(std::string newName)
{
	name = newName;
}

float Building::getCoefficient()
{
	return employees / (float)(employees + freeWorkingSeats);
}

int Building::peoplePerFloor()
{
	return (employees + freeWorkingSeats) / floors;
}

int Building::officesPerFloor()
{
	short currentFloors = floors - restaurant;
	return offices / currentFloors;
}

int Building::peoplePerOffice()
{
	return (employees + freeWorkingSeats) / offices;
}