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
            public int[] _penalty;

            public string Name => _name;
            public string Surname => _surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (_penalty == null) return default(int[]);
                    else
                    {
                        int[] penaltyTimes = new int[_penalty.Length];
                        for (int i = 0; i < penaltyTimes.Length; i++)
                            penaltyTimes[i] = _penalty[i];
                        return penaltyTimes;
                    }
                }
            }

            public int TotalTime
            {
                get
                {
                    if (_penalty == null) return 0;
                    else
                    {
                        int totalTime = 0;
                        for (int i = 0; i < _penalty.Length; i++)
                            totalTime += _penalty[i];
                        return totalTime;
                    }
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (_penalty == null)
                        return false;
                    bool isExpelled = true;
                    for (int i = 0; i < _penalty.Length; i++)
                        if (_penalty[i] == 10)
                        {
                            isExpelled = false;
                            break;
                        }
                    return isExpelled;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penalty = new int[10];
            }

            public void PlayMatch(int time)
            {
                if (_penalty == null) return;
                
                for(int i = 0; i<_penalty.Length; i++)
                {
                    if (_penalty[i] == 0)
                    {
                        _penalty[i] = time;
                        break;
                    }
                    
                }

            }

            public static void Sort(Participant[] array)
            {

                if (array == null) return;
                if (array.Length != 1)
                {
                    for (int i = 1, j = 2; i < array.Length;)
                    {
                        if (i == 0 || array[i].TotalTime >= array[i - 1].TotalTime)
                        {
                            i = j;
                            j++;
                        }
                        else
                        {
                            (array[i], array[i - 1]) = (array[i - 1], array[i]);
                            i--;
                        }
                    }

                }
            }

            public void Print()
            {
                Console.Write("{0,-20} {1,-20}", Name, Surname);
            }
        }
    }
}
