using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            private int _count;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return default(double[]);
                    double[] coefs = new double[_coefs.Length];
                    Array.Copy(_coefs, coefs, coefs.Length);
                    return coefs;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return default(int[,]);
                    int[,] marks = new int[_marks.GetLength(0),_marks.GetLength(1)];
                    for (int i = 0;  i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++) marks[i, j] = _marks[i, j];
                    }
                    return marks;
                }
            }

            public double TotalScore
            {
                get
                {
                    if (_marks == null || _coefs == null) return default(double);
                    double total = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        int max = 0, min = 7, sum = 0;
                        for (int j = 0;  j < _marks.GetLength(1); j++)
                        {
                            if (_marks[i, j] > max) max = _marks[i, j];
                            if (_marks[i, j] < min) min = _marks[i, j];
                            sum += _marks[i, j];
                        }
                        sum -= min;
                        sum -= max;
                        total += sum * _coefs[i];
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4,7];
                _count = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || _coefs == null) return;
                for (int i = 0; i < coefs.Length;i++) _coefs[i] = coefs[i];
            }
            public void Jump(int[] marks)
            {
                if (marks == null || _marks == null || _count >= 4) return;

                for (int j = 0; j < marks.Length; j++) _marks[_count, j] = marks[j];
                _count++;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for(int i = 1, j = 2; i < array.Length;)
                {
                    if (i == 0 || array[i - 1].TotalScore > array[i].TotalScore)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        var temp = array[i - 1];
                        array[i-1] = array[i];
                        array[i] = temp;
                        i--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine("Name: " + _name);
                Console.WriteLine("Surname: " + _surname);
                Console.WriteLine("Coefs:");

                foreach (double item in _coefs)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Marks:");
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0;  j < _marks.GetLength(1); j++) Console.Write($"{_marks[i,j],3}");
                    Console.WriteLine();
                }

                
            }
        }
    }
}
