using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            // поля
            private string _name;
            private string _surname;
            private int[] _penaltytimes;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltytimes == null) return null;
                    int[] results = new int[_penaltytimes.Length];
                    Array.Copy(_penaltytimes, results, results.Length);
                    return results;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltytimes == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        sum += _penaltytimes[i];
                    }
                    return sum;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_penaltytimes == null) return true;
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        if (_penaltytimes[i] == 10)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            // конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

            // остальные методы
            public void PlayMatch(int time)
            {
                if (_penaltytimes == null) return;
                Array.Resize(ref _penaltytimes, _penaltytimes.Length + 1);
                _penaltytimes[_penaltytimes.Length - 1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {TotalTime} {IsExpelled}");
            }
        }


    }
}
