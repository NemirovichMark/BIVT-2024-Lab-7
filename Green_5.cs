using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            // поля
            private string _name;
            private string _surname;
            private int[] _marks;

            // свойства
            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] copy = new int[_marks.Length];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return _marks.Average();
                }
            }

            // конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            // остальные методы
            public void Exam(int mark)
            {
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
                Console.WriteLine($"{Name} {Surname} {AvgMark:F2}");
            }
        }

        public struct Group
        {
            // поля
            private string _name;
            private Student[] _students;
            private int _studentCount;

            // свойства
            public string Name => _name;
            public Student[] Students => _students;
            public double AvgMark
            {
                get
                {
                    if (_studentCount == 0) return 0;
                    double totalAvg = 0;
                    for (int i = 0; i < _studentCount; i++)
                    {
                        totalAvg += _students[i].AvgMark;
                    }
                    return totalAvg / _studentCount;
                }
            }

            // конструкторы
            public Group(string name, int maxStudents)
            {
                _name = name;
                _students = new Student[maxStudents];
                _studentCount = 0;
            }

            // остальные методы
            public void Add(Student student)
            {
                if (_studentCount < _students.Length)
                {
                    _students[_studentCount] = student;
                    _studentCount++;
                }
            }

            public void Add(params Student[] students)
            {
                foreach (var student in students)
                {
                    Add(student);
                }
            }

            public static void SortByAvgMark(Group[] groups)
            {
                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - 1 - i; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            (groups[j], groups[j + 1]) = (groups[j + 1], groups[j]);   
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {AvgMark:F2}");
                for (int i = 0; i < _studentCount; i++)
                {
                    _students[i].Print();
                }
            }
        }
    }
}