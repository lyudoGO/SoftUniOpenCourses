#pragma once
#include "Person.h"

class GuestTeacher : public Person
{
private:
 float courseSalary;
public:
 GuestTeacher();
 GuestTeacher(unsigned short, string, Course, float);
 ~GuestTeacher();

 void toString();

 float getCourseSalary();
 void setCorseSalary(float);
};

