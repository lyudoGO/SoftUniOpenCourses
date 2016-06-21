#include "GuestTeacher.h"

GuestTeacher::GuestTeacher()
{
}

GuestTeacher::GuestTeacher(unsigned short id, string name, Course course, float courseSalary)
 :Person(id, name, course)
{
 this->setCorseSalary(courseSalary);
}

GuestTeacher::~GuestTeacher()
{
}

void GuestTeacher::toString()
{
 Person::toString();
 cout << "Course salary: " << this->courseSalary << endl;
};

float GuestTeacher::getCourseSalary()
{
 return this->courseSalary;
};

void GuestTeacher::setCorseSalary(float courseSalary)
{
 if (courseSalary < 0)
 {
  throw new invalid_argument("Course salary cannot be negative");
 }
 this->courseSalary = courseSalary;
};