//Make a program that is used to provide data about students, teachers and guest teachers in
//SoftUni.
//The data for studens :
//	-Id(0 - 65535)
//	- Name(std::string)
//	- Current course(only one must be written here)
//	- Current points for the course(0 – 100)
//	- Average evaluation mark(2.00 – 6.00, if this is the first course of the student 0 must be shown)
//The data for teachers
//	- Id(0 - 65535)
//	- Name(std::string)
//	- Current course(only one must be written here)
//	- Monthly salary(float)
//	- How many days have passed since he joined SoftUni(0 – 65535)
//The data for guest teachers
//	- Id(0 – 65535)
//	- Name(std::string)
//	- Current course
//	- Salary for course
//Use as many child / parent classes as you think for needed !
//How the program will be used :
//1. User starts the program and choses option with number entered from keyboard :
//	1. Get data for student with ID
//	2. Get data for teacher with ID
//	3. Get data for gest teacher with ID
//	4. Add data for new student
//	5. Add data for new teacher
//	6. Add data for new guest teacher
//2. When user chooses the option that desires if it is a “Get data” all the information
//described above is shown.If the user chooses option that is “Add data” he is asked
//to write all the parameters and they are then they are stored in the program.
//Maximum students that can be stored in the program are 65535
//Maximum teachers that can be stored in the program are 65535
//Maximum guest teachers that can be stored in the program are 65535
#pragma once
#include <iostream>
#include <string>
#include "Data.h"
#include "Student.h"
#include "Teacher.h"
#include "GuestTeacher.h"

using namespace std;

void printMenu();
void processInput(int input);
void fillData();
void addStudent();
void addTeacher();
void addGuestTeacher();
unsigned short inputId();

Data db;

int main()
{
 db = Data();
 fillData();
 printMenu();
 int input = 0;
 
 while (true)
 {
  cout << "Please, chouse: ";
  cin >> input;
  processInput(input);
 }

 return 0;
}

void printMenu()
{
 cout << "1. Get data for student with ID" << endl;
 cout << "2. Get data for teacher with ID" << endl;
 cout << "3. Get data for gest teacher with ID" << endl;
 cout << "4. Add data for new student" << endl;
 cout << "5. Add data for new teacher" << endl;
 cout << "6. Add data for new guest teacher" << endl;
 cout << "7. Exit" << endl;
}

void processInput(int input)
{
 switch (input)
 {
  case 1:
   db.getStudentDataById(inputId());
   break;
  case 2:
   db.getTeacherDataById(inputId());
   break;
  case 3:
   db.getGuestTeacherDataById(inputId());
   break;
  case 4:
   addStudent();
   break;
  case 5:
   addTeacher();
   break;
  case 6:
   addGuestTeacher();
   break;
  case 7:
   exit(0);
   break;
  default:
   cout << "Wrong choice!" << endl;
   break;
 }
}

void fillData()
{
 db.addStudentData(Student(db.sCount + 1, "Georgi Ivanov", Course::CPPROGRAMMING, 50, 3.5f));
 db.addStudentData(Student(db.sCount + 1, "Iva Petkov", Course::LINUXPROGRAMMING, 90, 5.5f));
 db.addStudentData(Student(db.sCount + 1, "Kiro Mihov", Course::CROGRAMMING, 80, 5.1f));

 db.addTeacherData(Teacher(db.tCount + 1, "Svetlin Nakov", Course::WINDOWSPROGRAMMING, 3500, 850));
 db.addTeacherData(Teacher(db.tCount + 1, "Jordan Georgiev", Course::LINUXPROGRAMMING, 2000, 650));
 db.addTeacherData(Teacher(db.tCount + 1, "Ivan Jonkov", Course::CROGRAMMING, 2100, 585));

 db.addGuestTeacherData(GuestTeacher(db.gtCount + 1, "Martin Kuvandjiev", Course::CPPROGRAMMING, 900));
 db.addGuestTeacherData(GuestTeacher(db.gtCount + 1, "Georgi Georgiev", Course::CROGRAMMING, 800));
 db.addGuestTeacherData(GuestTeacher(db.gtCount + 1, "Ivo Petrov", Course::LINUXPROGRAMMING, 800));
}

void addStudent()
{
 string name;
 unsigned short points = 0;
 float mark = 0;
 int coursId = 0;

 cout << "Enter students name: "; 
 getchar();
 getline(cin, name);

 cout << "Enter students points: "; 
 cin >> points;

 cout << "Enter evualation mark: ";
 cin >> mark;

 cout << "Enter course from 0 to 3: ";
 cin >> coursId;

 db.addStudentData(Student(db.sCount + 1, name, (Course)coursId, points, mark));
}

void addTeacher()
{
 string name;
 unsigned short days = 0;
 float salary = 0;
 int coursId = 0;

 cout << "Enter teacher name: ";
 getchar();
 getline(cin, name);

 cout << "Enter joined days: ";
 cin >> days;

 cout << "Enter salary: ";
 cin >> salary;

 cout << "Enter course from 0 to 3: ";
 cin >> coursId;

 db.addTeacherData(Teacher(db.tCount + 1, name, (Course)coursId, salary, days));
}

void addGuestTeacher()
{
 string name;
 float salary = 0;
 int coursId = 0;

 cout << "Enter guest teacher name: ";
 getchar();
 getline(cin, name);

 cout << "Enter salary: ";
 cin >> salary;

 cout << "Enter course from 0 to 3: ";
 cin >> coursId;

 db.addGuestTeacherData(GuestTeacher(db.gtCount + 1, name, (Course)coursId, salary));
}

unsigned short inputId()
{
 unsigned short id = 0;
 cout << "Enter id: ";
 cin >> id;
 return id;
}