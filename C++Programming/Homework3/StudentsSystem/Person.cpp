#pragma once
#include <iostream>
#include <string>
#include "Person.h"

const char* enumText[] { "C Programming", "C++ Programming", "Linux Programming", "Windows Programming" };

Person::Person()
{
}

Person::Person(unsigned short id, string name, Course course)
{
 this->setId(id);
 this->setName(name);
 this->course = course;
}

Person::~Person()
{
}

void Person::toString()
{
 cout << "Id: " << this->id << endl;
 cout << "Name: " << this->name << endl;
 cout << "Current course: " << enumText[course] << endl;
};

unsigned short Person::getId()
{
 return this->id;
};

void Person::setId(unsigned short id)
{
 if (id < 0)
 {
  throw new invalid_argument("Id cannot be negative!");
 }
 this->id = id;
};

string Person::getName()
{
 return this->name;
};

void Person::setName(string name)
{
 if (name.length() < 3 || 50 < name.length())
 {
  throw new invalid_argument("Name should be between 3 and 50 symbols!");
 }
 this->name = name;
};

Course Person::getCourse()
{
 return this->course;
};

void Person::setCourse(Course course)
{
 this->course = course;
};
