#pragma once
#include <iostream>
#include "Course.h"

using namespace std;

// Base Class
class Person
{
protected:
 unsigned short id;
 string name;
 Course course;
public:
 Person();
 Person(unsigned short, string, Course);
 ~Person();

 unsigned short getId();
 void setId(unsigned short);

 string getName();
 void setName(string);

 Course getCourse();
 void setCourse(Course);

 virtual void toString() = 0;
};