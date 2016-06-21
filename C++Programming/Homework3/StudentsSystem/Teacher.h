#pragma once
#include <iostream>
#include "Person.h"
#include "Course.h"

using namespace std;

class Teacher : public Person
{
private:
 float salary;
 unsigned short days;
public:
 Teacher();
 Teacher(unsigned short, string, Course, float, unsigned short);
 ~Teacher();

 void toString();

 float getSalary();
 void setSalary(float);

 unsigned short getDays();
 void setDays(unsigned short);
};

