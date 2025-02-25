using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            private int[] _minuts;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_minuts == null) return null;
                    int[] copy = new int[_minuts.Length];
                    Array.Copy(_minuts, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    int sum = 0;
                    for(int i = 0; i < _minuts.Length; i++)
                    {
                        sum += _minuts[i];
                    }
                    return sum;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    bool isExpelled = false;
                    for(int i = 0; i < _minuts.Length; i++)
                    {
                        if (_minuts[i] == 10)
                        {
                            isExpelled = true;
                            break;
                        }
                    }
                    return isExpelled;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _minuts = new int[] {};
            }


            public void PlayMatch(int time)
            {
                int[] arr = new int[_minuts.Length + 1];
                for(int i = 0; i < _minuts.Length; i++)
                {
                    arr[i] = _minuts[i];
                }
                arr[arr.Length - 1] = time;
                _minuts = arr;
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => x.TotalTime.CompareTo(y.TotalTime));
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - {TotalTime}");
            }
        }
    }
}
