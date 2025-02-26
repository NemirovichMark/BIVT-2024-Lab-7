using System;
using System.Linq;


namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _session_outcome;

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
                    if (_marks == null)
                    {
                        return default; 
                    }

                    double sum = 0;
                    foreach (int mark in _marks)
                    {
                        sum += mark;
                    }
                    return sum / _marks.Length;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    return _session_outcome;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[] { 2, 2, 2 }; // инициализируем массив двойками
                _session_outcome = false;
            }

            public void Exam(int mark)
            {
                if (_session_outcome) return;
                if (mark < 2 || mark > 5) return;
                if (mark == 2)
                {
                    _session_outcome = true;
                    return;
                }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 2)
                    {
                        _marks[i] = mark;
                        return;
                    }
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

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExpelled}");
            }
        }
    }
}
