using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

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
                    Array.Copy(_penaltyTimes, copy, _penaltyTimes.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null || _penaltyTimes.Length == 0)
                        return 0;
                    return _penaltyTimes.Sum();
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes == null) return false;
                    return _penaltyTimes.Any(time => time == 10);
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
                
                if (time < 0 || time > 10 || (time != 0 && time != 2 && time != 5 && time != 10))
                {
                    return;
                }

                
                int[] newPenaltyTimes = new int[_penaltyTimes.Length + 1];
                _penaltyTimes.CopyTo(newPenaltyTimes, 0);
                newPenaltyTimes[_penaltyTimes.Length] = time;
                _penaltyTimes = newPenaltyTimes;
            }

            
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            
            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.WriteLine("Штрафные минуты:");

                if (_penaltyTimes != null && _penaltyTimes.Length > 0)
                {
                    foreach (var time in _penaltyTimes)
                    {
                        Console.Write($"{time} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Нет данных о штрафных минутах");
                }

                Console.WriteLine($"Общее время: {TotalTime}");

                if (IsExpelled)
                {
                    Console.WriteLine("True (исключен)");
                }
                else
                {
                    Console.WriteLine("False (не исключен)");
                }
            }
        }
    }
}