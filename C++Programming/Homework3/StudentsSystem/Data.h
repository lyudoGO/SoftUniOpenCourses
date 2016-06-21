#pragma once
#include <vector>
#include "Person.h"
#include "Student.h"
#include "Teacher.h"
#include "GuestTeacher.h"

#define MAX_DATA_COUNT 65535

class Data
{
public:
 Data();
 ~Data();

 unsigned short sCount = 0;
 unsigned short tCount = 0;
 unsigned short gtCount = 0;

 vector<Student> students;
 vector<Teacher> teachers;
 vector<GuestTeacher> guestTeachers;

 void getStudentDataById(unsigned short id);
 void getTeacherDataById(unsigned short id);
 void getGuestTeacherDataById(unsigned short id);

 void addStudentData(Student student);
 void addTeacherData(Teacher teacher);
 void addGuestTeacherData(GuestTeacher gTeacher);
};

