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
                if (time != 0 && time != 2 && time != 5 && time != 10)
                {
                    Console.WriteLine("Штрафное время должно быть 0, 2, 5 или 10 минут.");
                    return;
                }

                if (_penaltyTimes == null)
                {
                    _penaltyTimes = new int[0];
                }

                int[] newPenaltyTimes = new int[_penaltyTimes.Length + 1];

                for (int i = 0; i < _penaltyTimes.Length; i++)
                {
                    newPenaltyTimes[i] = _penaltyTimes[i];
                }

                newPenaltyTimes[newPenaltyTimes.Length - 1] = time;
                _penaltyTimes = newPenaltyTimes;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                Participant[] candidates = new Participant[array.Length];
                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (!array[i].IsExpelled)
                    {
                        candidates[count] = array[i];
                        count++;
                    }
                }
                for (int i = 0; i < count - 1; i++)
                {
                    for (int j = 0; j < count - 1 - i; j++)
                    {
                        if (candidates[j].TotalTime > candidates[j + 1].TotalTime)
                        {
                            Participant temp = candidates[j];
                            candidates[j] = candidates[j + 1];
                            candidates[j + 1] = temp;
                        }
                    }
                }
                for (int i = 0; i < count; i++)
                {
                    array[i] = candidates[i];
                }
                for (int i = count; i < array.Length; i++)
                {
                    array[i] = new Participant("Исключен", "Участник");
                }
            }

            public void Print()
            {
                Console.WriteLine($"Участник: {_name} {_surname}");
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
