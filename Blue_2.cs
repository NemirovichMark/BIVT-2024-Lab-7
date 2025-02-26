using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
                    if (_marks == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for(int j = 0; j < 5; j++)
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
                _marks = new int[2, 5];
            }

            public void Jump(int[] result)
            {
                if (_marks == null || result == null) return;
                int jump = 0;
                for(int i = 0; i < 5; i++)
                {
                    if (_marks[jump,i] != 0)
                    {
                        jump = 1;
                        break;
                    }
                }
                if(jump == 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (_marks[jump, i] != 0)
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
                        _marks[jump, i] = result[i];                    }
                }
                else
                {
                    return;
                }

            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1)
                    return;

                int n = array.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;

                            swapped = true;
                        }
                    }

                    if (!swapped)
                        break;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - {TotalScore} ");
            }

        }
    }
}
