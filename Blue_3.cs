using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    

    internal class Blue_3
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private int[] penaltyTimes;

            public string Name
            {
                get
                {
                    if (name == null)
                        return "";
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return "";
                    return surname;
                }
            }

            public int[] PenaltyTimes
            {
                get
                {
                    if (penaltyTimes == null)
                        return new int[0];
                    return penaltyTimes;
                }
            }

            public int TotalTime
            {
                get
                {
                    if (penaltyTimes == null)
                        return 0;

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
                        if (time == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }


            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penaltyTimes = new int[30];
            }

            public void PlayMatch(int time)
            {
                if (penaltyTimes == null)
                    return;

                for (int i = 0; i < penaltyTimes.Length; i++)
                {
                    if (penaltyTimes[i] == 0)
                    {
                        penaltyTimes[i] = time;
                        break;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => x.TotalTime.CompareTo(y.TotalTime));
            }
        }
    }
}
