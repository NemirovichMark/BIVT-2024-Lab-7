using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;

            public string Name => _name;
            public string Surname => _surname;

            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null) return null;
                    int[] copy = new int[_penaltyTimes.Length];
                    Array.Copy(_penaltyTimes, copy, copy.Length);
                    return copy;
                }
            }
            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null) return 0;

                    int total = 0;
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        total += _penaltyTimes[i];
                    }
                    return total;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null) return false;

                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        if (_penaltyTimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null) return;

                int[] newArray = new int[_penaltyTimes.Length + 1];
                Array.Copy(_penaltyTimes, newArray, _penaltyTimes.Length);
                _penaltyTimes = newArray;
                _penaltyTimes[_penaltyTimes.Length - 1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.WriteLine("Штрафные минуты:");

                if (_penaltyTimes != null)
                {
                    for (int i = 0; i < _penaltyTimes.Length; i++)
                    {
                        Console.Write($"{_penaltyTimes[i]} ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine($"Общее штрафное время: {TotalTime}");

                if (IsExpelled)
                {
                    Console.WriteLine("Статус: Дисквалифицирован");
                }
                else
                {
                    Console.WriteLine("Статус: Активен");
                }
            }
        }
       
    }
    
}
