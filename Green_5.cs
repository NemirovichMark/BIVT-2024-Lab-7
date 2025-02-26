using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            

            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }

            public int[] Marks
            {
                get
                {
                    if (_marks == null) return default;
                    return _marks;
                }
            }

            public double AvgMark
            {
                get
                {
                    double sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _marks.Length;
                }
            }
            public static void SortByAvgMark(Student[] array)
            {
                for (int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i].AvgMark <= array[i - 1].AvgMark)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Student temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
               
            }

            public void Exam(int mark)
            {
                if (_marks == null) return;
                if (mark < 2 || mark > 5) return;
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        break;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark}");
            }
        }

        public class Group
        {
            private string _name;
            private Student[] _students;
            private int _studentCount;
            private int _capacity;

            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }

            public Student[] Students
            {
                get
                {
                    if (_students == null || _studentCount == 0) return default;
                    Student[] result = new Student[_studentCount];
                    Array.Copy(_students, result, _studentCount);
                    return result;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_students == null || _studentCount == 0)
                    {
                        return 0;
                    }
                    double totalMark = 0;

                    for (int i = 0; i < _studentCount; i++)
                    {
                        totalMark += _students[i].AvgMark;
                    }
                    double averageMark = totalMark / _studentCount;

                    return averageMark;
                }
            }

            public static int StudentsCount(Group group)
            {
                if (group._students == null) return 0;
                return group._studentCount;
            }

            public Group(string name, int initialCapacity = 30)
            {
                _name = name;
                _capacity = initialCapacity;
                _students = new Student[_capacity];
                _studentCount = 0;
            }
            public void Add(Student student)
            {
                if (_studentCount == _capacity)
                {
                    ResizeArray();
                }

                _students[_studentCount] = student;
                _studentCount++;
            }

            public void Add(params Student[] students)
            {
                foreach (Student student in students)
                {
                    Add(student);
                }
            }

            private void ResizeArray()
            {
                
                _capacity *= 2;
                if (_capacity <= 0) _capacity = 30;

                Student[] newStudents = new Student[_capacity];

                Array.Copy(_students, newStudents, _studentCount);

                _students = newStudents;
            }

            public static void SortByAvgMark(Group[] array)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j + 1].AvgMark)
                        {
                            Group temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {AvgMark}");
                foreach (var student in _students)
                {
                    student.Print();
                }
            }
        }
    }
}
