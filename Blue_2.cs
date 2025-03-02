using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private int[,] _marks;

            private int _count;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] results = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < results.GetLength(0); i++)
                    {
                        for (int j = 0; j < results.GetLength(1); j++)
                        {
                            results[i, j] = _marks[i, j];
                        }
                    }
                    return results;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int [2,5];

                _count = 0;
            }

            // остальные методы
            public void Jump(int[] result)
            {
                if (result == null || _marks == null || _count > 1) return;
                for (int j = 0; j < _marks.GetLength(1); j++)
                {
                     _marks[_count, j]  = result[j];
                }
                _count++;
                
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1;i++)
                {
                    for (int j = 0; j < array. Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {TotalScore}");
            }
        }
    }
}
