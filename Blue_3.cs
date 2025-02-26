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
            private int[] _penaltytimes;

            public string Name => _name;

            public string Surname => _surname;

            public int[] PenaltyTimes
            {
                get
                {
                    if (_penaltytimes == null) return null;
                    int[] copy = new int[_penaltytimes.Length];
                    Array.Copy(_penaltytimes, copy, _penaltytimes.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penaltytimes == null) return 0;
                    int time = 0;
                    for (int i = 0; i < _penaltytimes.Length; i++) time += _penaltytimes[i];
                    return time;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penaltytimes == null) return false;
                    for (int i = 0; i < _penaltytimes.Length; i++)
                    {
                        if (_penaltytimes[i] == 10) return true;
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltytimes = new int[0];
            }

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
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine("{0} {1}     \t{2} {3}", _name, _surname, TotalTime, IsExpelled);
            }
        }
    }
}
