using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (_marks == null) return null;
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy, _marks.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int score = 0;
                    for (int i = 0; i < _marks.GetLength(0); i++) for (int j = 0; j < _marks.GetLength(1); j++) score += _marks[i, j];
                    return score;
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
                if ((_marks == null) || (result == null)) return;
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    bool skip = false;
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        if (_marks[i, j] != 0)
                        {
                            skip = true;
                            break;
                        }
                    }
                    if (skip) continue;
                    for (int j = 0; j < 5; j++)
                    {
                        _marks[i, j] = result[j];
                    }
                    break;
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine("{0} {1}    \t{2}", _name, _surname, TotalScore);
            }
        }
    }
}
