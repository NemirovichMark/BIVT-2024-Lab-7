using System;
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

            private int _curJump;

            public string Name => _name;
            public string Surname => _surname;

            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;

                    var copy = new double[_coefs.Length];
                    Array.Copy(_coefs, copy, _coefs.Length);
                    return copy;
                }
            }

            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;

                    var copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public double TotalScore { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name != null ? name : "-";
                _surname = surname != null ? surname : "-";
                _coefs = new double[] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                TotalScore = 0;

                _curJump = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                if (coefs == null || coefs.Length != 4 || _coefs == null) return;

                Array.Copy(coefs, _coefs, coefs.Length);
            }

            public void Jump(int[] marks)
            {
                if (_curJump >= 4 || marks == null || marks.Length != 7 || _marks == null || _coefs == null) return;

                for (int j = 0; j < marks.Length; j++)
                {
                    _marks[_curJump, j] = marks[j];
                }

                TotalScore += (marks.Sum() - marks.Max() - marks.Min()) * _coefs[_curJump];
                _curJump++;
            }

            public void Print()
            {
                if (_coefs == null || _marks == null) return;

                Console.WriteLine($"Имя: {_name}");
                Console.WriteLine($"Фамилия: {_surname}");

                Console.Write("Коэффициенты:\t");
                foreach (var coef in _coefs)
                {
                    Console.Write($"{coef}\t");
                }

                Console.WriteLine();

                Console.Write("Оценки:");
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    Console.Write("\t");
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.Write($"{_marks[i, j]}\t");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine($"Результат: {Math.Round(TotalScore, 2)}");
                Console.WriteLine();
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                int n = array.Length, i = 1, j = 2;
                while (i < n)
                {
                    if (i == 0 || array[i - 1].TotalScore > array[i].TotalScore)
                    {
                        i = j;
                        j++;
                    }
                    else
                    {
                        (array[i - 1], array[i]) = (array[i], array[i - 1]);
                        i--;
                    }
                }
            }
        }
    }
}