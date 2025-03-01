using System;
using System.Linq;


namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _exams_taken_count;

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[4]; // инициализаця нулями
                _exams_taken_count = 0;
            }

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
                    return (int[])_marks.Clone(); // возвращаем копию массива
                }
            }

            public double AvgMark
            {
                get
                {
                    if (_exams_taken_count == 0) return 0; 

                    double sum = 0;
                    for (int i = 0; i < _exams_taken_count; i++)
                    {
                        sum += _marks[i];
                    }
                    return sum / _exams_taken_count;
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

            public bool IsExcellent
            {
                get
                {

                    if (_marks == null || _marks.Length == 0) return false;
                    if (_exams_taken_count != _marks.Length) return false;
                    for (int i = 0; i < _exams_taken_count; i++)
                    {
                        if (_marks[i] < 4)
                        {
                            return false;
                        }
                    }
                    return true; 
                }
            }
            public void Exam(int mark)
            {
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
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark} {IsExcellent}");
            }

        }

    }




    
}
