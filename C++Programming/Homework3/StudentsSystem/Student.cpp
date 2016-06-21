#include "Student.h"

Student::Student()
{
}

Student::Student(unsigned short id, string name, Course course, unsigned short coursePoints, float evaluationMark)
 : Person(id, name, course)
{
 this->setCoursePoints(coursePoints);
 this->setEvaluationMark(evaluationMark);
};

Student::~Student()
{
}

void Student::toString()
{
 Person::toString();
 cout << "Course points: " << (int)coursePoints << endl;
 cout << "Evaluation Mark: " << evaluationMark << endl;
};

unsigned char Student::getCoursePoints()
{
 return coursePoints;
};

void Student::setCoursePoints(unsigned short coursePoints)
{
 if (coursePoints < 0 || 100 < coursePoints)
 {
  throw new invalid_argument("Course points should be in range 0 ... 100!");
 }
 this->coursePoints = coursePoints;
};

float Student::getEvaluationMark()
{
 return this->evaluationMark;
};

void Student::setEvaluationMark(float evaluationMark)
{
 if (evaluationMark < 2 || 6 < evaluationMark)
 {
  throw new invalid_argument("Evaluation mark should be in range 2 ... 6!");
 }
 this->evaluationMark = evaluationMark;
};