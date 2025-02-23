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
            //поля
            private string _name;
            private string _surname;
            private int[] _marks;

            //свойства
            public string Name  => _name;
            public string Surname  => _surname;
            public int[] Marks  => _marks;
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return _marks.Average();
                }
            }

            //конструкторы
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5];
            }

            //остальные методы
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

            public static void SortByAvgMark(Student [] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j+1].AvgMark)
                        {
                            (array[j],array[j+1])=(array[j+1],array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark}");
            }
        }

        public struct Group
        {
            //поля
            private string _name;
            private List<Student> _students;

            //свойства
            public string Name => _name;
            public List<Student> Students => _students;
            public double AvgMark => _students.Average(s => s.AvgMark); // лямбда выражение для каждого студента мы берем его свойсвто среднее занчение


            //конструкторы
            public Group(string name)
            {
                _name = name;
                _students = new List<Student>();
            }

            //остальные методы
            public void Add(Student student)
            {
                _students.Add(student);
            }
            public void Add(params Student[] students)
            {
                _students.AddRange(students);
            }

            public static void SortByAvgMark(Group[] groups)
            {
                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - 1 - i; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            Group temp = groups[j];
                            groups[j] = groups[j + 1];
                            groups[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {AvgMark:F2}");
                foreach (var student in _students)
                {
                    student.Print();
                }
            }
        }
    }
}
