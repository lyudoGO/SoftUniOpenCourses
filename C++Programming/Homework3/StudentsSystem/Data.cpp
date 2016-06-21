#include "Data.h"


Data::Data()
{
}


Data::~Data()
{
}

void Data::getStudentDataById(unsigned short id)
{
 try
 {
  Student student = this->students.at(id - 1);
  student.toString();
 }
 catch (const out_of_range& ex)
 {
  cout << "No student with thise Id!" << endl;
 }
}

void Data::getTeacherDataById(unsigned short id)
{
 try
 {
  Teacher teacher = this->teachers.at(id - 1);
  teacher.toString();
 }
 catch (const out_of_range& ex)
 {
  cout << "No teacher with thise Id!" << endl;
 }
}

void Data::getGuestTeacherDataById(unsigned short id)
{ 
 try
 {
  GuestTeacher gTeacher = this->guestTeachers.at(id - 1);
  gTeacher.toString();
 }
 catch (const out_of_range& ex)
 {
  cout << "No guest teacher with thise Id!" << endl; 
 }
}

void Data::addStudentData(Student student)
{
 if (this->sCount > MAX_DATA_COUNT)
 {
  throw new out_of_range("Students data overflow!");
 }
 this->students.push_back(student);
 this->sCount++;
}

void Data::addTeacherData(Teacher teacher)
{
 if (this->sCount > MAX_DATA_COUNT)
 {
  throw new out_of_range("Students data overflow!");
 }
 this->teachers.push_back(teacher);
 this->tCount++;
}

void Data::addGuestTeacherData(GuestTeacher gTeacher)
{
 if (this->sCount > MAX_DATA_COUNT)
 {
  throw new out_of_range("Students data overflow!");
 }
 this->guestTeachers.push_back(gTeacher);
 this->gtCount++;
}