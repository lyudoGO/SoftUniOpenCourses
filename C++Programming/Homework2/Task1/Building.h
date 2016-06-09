#pragma once
#include <iostream>

class Building
{
private:
	short floors;
	short offices;
	short restaurant;
	int employees;
	int freeWorkingSeats;
	float coefficient = 0;
	std::string name;

public:
	Building();
	Building(short, short, short);
	Building(int, int, std::string);
	Building(short, short, short, int, int, std::string);
	~Building();

	short getFloors();
	void setFloors(short);

	short getOffices();
	void setOffices(short);

	short getRestaurant();
	void setRestaurant(short);

	int getEmployees();
	void setEmployees(int);

	int getWorkingSeats();
	void setWorkingSeats(int);

	std::string getName();
	void setName(std::string);

	float getCoefficient();

	int peoplePerFloor();
	int officesPerFloor();
	int peoplePerOffice();
};