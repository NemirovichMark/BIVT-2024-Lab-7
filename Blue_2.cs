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
            private int _globalI;
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
                _globalI = 0;
            }

            public void Jump(int[] result)
            {
                if (result == null || _globalI > 1 || _marks == null) return;

                if (_globalI == 0)
                {

                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[0, j] = result[j];
                    }
                    _globalI++;
                }
                else if (_globalI == 1)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[1, j] = result[j];
                    }
                    _globalI++;
                }
            }





            public static void Sort(Participant[] array)
            {

                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore) 
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


