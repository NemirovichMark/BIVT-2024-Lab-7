using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab_6
{
    internal class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coef;
            private int _count;
            private int[,] _marks;
            private double _total;

            public string Name {
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

            public double TotalScore
            {
                get 
                {
                    return _total;
                }
            }
            public double[] Coef
            {
                get {
                    if (_coef == null) return null;
                    double[] copy = new double[_coef.Length];
                    Array.Copy(_coef, copy, _coef.Length);
                    return copy;
                }
            }
            public int[,] Marks
            {
                get{
                    if (_marks == null) return null;
                    int[,] copy_marks = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < copy_marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < copy_marks.GetLength(1); j++)
                        {
                            copy_marks[i, j] = _marks[i, j];
                        }
                    }
                    return copy_marks;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _count = 0;
                _coef = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _total = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != 4) return;
                for (int i = 0; i < coefs.Length; i++)
                {
                    _coef[i] = coefs[i];
                }
            }

            public void Total()
            {
                if (_marks == null) return;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    int[] array = new int[7];
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        array[j] = _marks[i, j];
                    }
                    Array.Sort(array);
                    for (int k = 1; k < array.Length - 1; k++)
                    {
                        _total += array[k] * _coef[i];
                    }
                }
            }

            public void Jump(int[] marks)
            {
                if (marks == null || marks.Length != 7) return;
                if (_count >= 4) return;
                for (int i = 0; i < marks.Length; i++)
                {
                    _marks[_count, i] = marks[i];
                }
                _count++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j]._total < array[j+1]._total)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }

                }
            }
            public void Print()
            {
                Console.Write(_name + " ");
                Console.Write(_surname + " ");
                Console.WriteLine(_total + " ");
            }
        }
    }
}
