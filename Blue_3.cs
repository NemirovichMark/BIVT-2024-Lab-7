using System;


namespace Lab_6
{
    public class Blue_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penalty;

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
                _penalty = new int[0];
            }

            public void PlayMatch(int time)
            {
                if (_penalty == null) return;
                int[] newar = new int[_penalty.Length+1];
                for(int i = 0; i< _penalty.Length; i++)
                    newar[i] = _penalty[i];
                _penalty = newar;
                _penalty[_penalty.Length-1] = time;

            }

            public static void Sort(Participant[] array)
            {

                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalTime > array[j].TotalTime)
                        {
                            (array[j + 1], array[j]) = (array[j], array[j + 1]);
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
