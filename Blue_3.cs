using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant {
            private string _name;
            private string _surname;
            private int[] _penalty_minutes;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyMinutes {
                get
                {
                    int[] newArr = new int[_penalty_minutes.Length];
                    Array.Copy(_penalty_minutes, newArr, _penalty_minutes.Length); 
                    return newArr;
                }
            }

            public int TotalTime {
                get {
                    if (_penalty_minutes == null || _penalty_minutes.Length == 0) { return 0; }
                    return _penalty_minutes.Sum();
                }
            }

            public bool IsExpelled {
                get {
                    if (_penalty_minutes == null || _penalty_minutes.Length == 0) { return false; }
                    foreach (int p in _penalty_minutes) {
                        if (p >= 10) { 
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string name, string surname) { 
                _name = name;
                _surname = surname;
                _penalty_minutes = new int[0];
            }

            public void PLayMatch(int time) {
                if (time < 0) { Console.WriteLine("Введите корректное время"); }
                else {
                    Array.Resize(ref _penalty_minutes, _penalty_minutes.Length + 1);
                    _penalty_minutes[_penalty_minutes.Length - 1] = time;
                }
            }

            public static void Sort(Participant[] array) {
                if (array == null) { return; }
                for (int i = 0; i <= array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i].TotalTime < array[j].TotalTime)
                        {
                            Participant tmp = array[i];
                            array[i] = array[j];
                            array[j] = tmp;
                        }
                    }
                }
            }

            public void Print() {
                Console.WriteLine($"{_name} {_surname} {TotalTime} {IsExpelled}");
            }
        }
    }
}
