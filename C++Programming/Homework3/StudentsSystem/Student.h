#pragma once
#include "Person.h"

class Student : public Person
{
private:
 unsigned short coursePoints;
 float evaluationMark = 0;
public: 
 Student(); 
 Student(unsigned short, string, Course, unsigned short, float);
 ~Student();

 void toString();

 unsigned char getCoursePoints();
 void setCoursePoints(unsigned short);

 float getEvaluationMark();
 void setEvaluationMark(float);
};

