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
                    if (_minuts == null) return 0;
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
                    if (_minuts == null) return false;
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
                _minuts = new int[0];
            }


            public void PlayMatch(int time)
            {
                if (_minuts == null) return;
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
                if (array == null || array.Length <= 1)
                    return;

                int n = array.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].TotalTime > array[j + 1].TotalTime)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;

                            swapped = true;
                        }
                    }
                    if (!swapped)
                        break;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - {TotalTime}");
            }
        }
    }
}
