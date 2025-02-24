using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpIndex;

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public string Surname
            {
                get
                {
                    return _surname;
                }
            }

            public double[] Coefs
            {
                get
                {
                    if (_coefs is null) return null;
                    double[] coefsCopy = new double[_coefs.Length];
                    Array.Copy(_coefs, coefsCopy, _coefs.Length);
                    return coefsCopy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks is null) return null;
                    int[,] marksCopy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            marksCopy[i, j] = _marks[i, j];
                        }
                    }
                    return marksCopy;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_marks is null || _coefs is null)
                    {
                        Console.WriteLine("error");
                        return 0;
                    }
                        
                    int coefsLen = _marks.GetLength(0), marksLen = _marks.GetLength(1);
                    double score = 0;
                    for (int i = 0; i < coefsLen; i++)
                    {
                        int markSum = 0, maxMarkIdx = 0, minMarkIdx = 0;
                        for (int j = 0; j < marksLen; j++)
                        {
                            markSum += _marks[i, j];
                            if (_marks[i, j] >= _marks[i, maxMarkIdx])
                            {
                                maxMarkIdx = j;
                            }
                            if (_marks[i, j] <= _marks[i, minMarkIdx])
                            {
                                minMarkIdx = j;
                                
                            }

                        }
                        markSum -= _marks[i, maxMarkIdx];
                        markSum -= _marks[i, minMarkIdx];
                        
                        score += markSum * _coefs[i];
                    }
                    return score;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = 2.5;
                }
                _marks = new int[4, 7];
                _jumpIndex = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (_coefs is null || coefs is null || coefs.Length != 4)
                {
                    Console.WriteLine("error");
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (coefs[i] < 2.5 || coefs[i] > 3.5)
                    {
                        return;
                    }
                }
                Array.Copy(coefs, _coefs, 4);
            }

            public void Jump(int[] marks)
            {
                if (marks is null || marks.Length != 7)
                {
                    return;
                }

                for (int i = 0; i < 7; i++)
                {
                    if (marks[i] < 1 || marks[i] > 6)
                    {
                        return;
                    }
                }
                for (int i = 0; i < 7; i++)
                {
                    _marks[_jumpIndex, i] = marks[i];
                }
                _jumpIndex++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length < 2) return;

                int n = array.Length;
                for (int i = 1, j = 2; i < n;)
                {
                    if (i == 0 || array[i].TotalScore < array[i - 1].TotalScore)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        Participant temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        i--;
                    }
                }
            }

            public void Print()
            {
                if (_surname == "" || _name == "")
                {
                    return;
                }

                Console.WriteLine($"{_name} {_surname} {TotalScore:F2}");
            }
        }

        public static void PrintArr(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public static void PrintArr(double[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public static void PrintArr(Participant[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i].TotalScore} ");
            Console.WriteLine();
        }

    }
}

