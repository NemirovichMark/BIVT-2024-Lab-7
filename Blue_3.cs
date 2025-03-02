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
            private readonly string name;
            private readonly string surname;
            private int[] penaltyTimes;

            public string Name => name;
            public string Surname => surname;
            public int[] PenaltyTimes
            {
                get
                {
                    if (penaltyTimes == null) return null;
                    int[] copy = new int[penaltyTimes.Length];
                    Array.Copy(penaltyTimes, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (penaltyTimes == null) return 0;
                    
                    int total = 0;
                    foreach (int time in penaltyTimes)
                    {
                        total += time;
                    }
                    return total;
                }
            }

            public bool IsExpelled
            {
                get
                {
                    if (penaltyTimes == null)
                        return false;

                    foreach (int time in penaltyTimes)
                    {
                        if (time == 10) return true;
                    }
                    return false;
                }
            }
            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                penaltyTimes = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (penaltyTimes == null) return;


                int[] newArray = new int[penaltyTimes.Length + 1];
                Array.Copy(penaltyTimes, newArray, penaltyTimes.Length);
                penaltyTimes = newArray;
                penaltyTimes[penaltyTimes.Length - 1] = time;
            }


            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => x.TotalTime.CompareTo(y.TotalTime));
            }


            public void Print() { }

        }
    }
}

