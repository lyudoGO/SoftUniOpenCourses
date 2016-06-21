#pragma once
#include "Teacher.h"

Teacher::Teacher()
{
}

Teacher::Teacher(unsigned short id, string name, Course course, float salary, unsigned short days)
 : Person(id, name, course)
{
 this->setSalary(salary);
 this->setDays(days);
}

Teacher::~Teacher()
{
}

void Teacher::toString()
{
 Person::toString();
 cout << "Salary: " << this->salary << endl;
 cout << "Days in SoftUni: " << this->days << endl;
}

float Teacher::getSalary()
{
 return this->salary;
};

void Teacher::setSalary(float salary)
{
 if (salary < 0)
 {
  throw new invalid_argument("Salary cannot be negative!");
 }
 this->salary = salary;
};

unsigned short Teacher::getDays()
{
 return this->days;
};

void Teacher::setDays(unsigned short days)
{
 if (days < 0)
 {
  throw new invalid_argument("Days cannot be negative!");
 }
 this->days = days;
};