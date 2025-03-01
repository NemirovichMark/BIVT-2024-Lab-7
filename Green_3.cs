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
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }

            public int[] Marks
            {
                get
                {
                    return (int[])_marks.Clone(); 
                }
            }


            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0)
                    {
                        return 0; 
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
                _marks = new int[] { 0, 0, 0 }; // инициализируем массив нулями
                _session_outcome = false;
            }

            public void Exam(int mark)
            {
                if (_session_outcome || _marks == null) return;
                if (mark < 2 || mark > 5) return;
                if (mark == 0)
                {
                    _session_outcome = true;
                    return;
                }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }

            public static void SortByAvgMark(Student[] array)
            {
                if (array == null) return;
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
