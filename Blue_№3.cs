using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_6;
namespace ConsoleApp6
{
    internal class Blue__3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;



            public int[] PenaltyTimes => _penaltyTimes;
            public string Name => _name;
            public string Surname => _surname;

            

            public int TotalTime => _penaltyTimes.Sum();
            public bool IsExpelled
            {
                get
                {
                    foreach (int time in _penaltyTimes)
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
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].TotalTime > array[j].TotalTime)
                        {
                            Participant temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.WriteLine($"Общее штрафное время: {TotalTime}");
                Console.WriteLine($"Дисквалифицирован: {IsExpelled}");
            }

        }
    }
}
