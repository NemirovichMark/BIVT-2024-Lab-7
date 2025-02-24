using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_2
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
                    if (_marks == null) { return null; }
                    int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < copy.GetLength(0); i++)
                    {
                        for (int j = 0; j < copy.GetLength(1); j++)
                        {
                            copy[i, j] = _marks[i, j];
                        }
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        for(int j = 0; j < 2; j++)
                        {
                            sum += _marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[5, 2];
            }

            public void Jump(int[] result)
            {
                int jump = 0;
                for(int i = 0; i < 5; i++)
                {
                    if (_marks[i,jump] != 0)
                    {
                        jump = 1;
                        break;
                    }
                }
                if(jump == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (_marks[i, jump] != 0)
                        {
                            jump = -1;
                            break;
                        }
                    }
                }
                if (jump != -1 && result.Length == 5)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        _marks[i, jump] = result[i];                    }
                }
                else
                {
                    return;
                }

            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => y.TotalScore.CompareTo(x.TotalScore));
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - {TotalScore} ");
            }

        }
    }
}
