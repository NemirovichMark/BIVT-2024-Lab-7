using System;


namespace Lab_6
{
    public class Blue_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return default(int[,]);
                    else
                    {
                        int[,] marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                        for (int i = 0; i < _marks.GetLength(0); i++)
                            for (int j = 0; j < _marks.GetLength(1); j++)
                                marks[i, j] = _marks[i, j];
                        return marks;
                    }
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    else
                    {
                        int sum = 0;
                        for (int i = 0; i < _marks.GetLength(0); i++)
                            for (int j = 0; j < _marks.GetLength(1); j++)
                                sum += _marks[i, j];
                        return sum;
                    }
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];

            }

            public void Jump(int[] result)
            {
                if (result == null || result.Length != 5) return;

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int k = 0; k < _marks.GetLength(1); k++)
                    {
                        sum += _marks[i, k];
                    }
                    if (sum != 0) continue;

                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {

                        _marks[i, j] = result[j];
                    }
                    break;
                }

            }



            public static void Sort(Participant[] array)
            {

                if (array == null) return;
                if (array.Length != 1)
                {
                    for (int i = 1, j = 2; i < array.Length;)
                    {
                        if (i == 0 || array[i].TotalScore <= array[i - 1].TotalScore)
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
