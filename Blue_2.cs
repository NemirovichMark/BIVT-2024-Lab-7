using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

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
            public int[,] Marks => _marks;

            public int TotalScore
            {
                get
                {
                    int sum = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
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
                if (result == null || result.Length != 5) return;

                for (int i = 0; i < 2; i++)
                {
                    bool isJumpEmpty = _marks[i, 0] == 0;
                    if (isJumpEmpty)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            _marks[i, j] = result[j];
                        }
                        break;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;

                int index = 1;
                int lastSorted = 0;

                while (index < array.Length)
                {
                    if (index == 0 || array[index - 1].TotalScore >= array[index].TotalScore)
                    {
                        lastSorted = index;
                        index++;
                    }
                    else
                    {
                        var temp = array[index];
                        array[index] = array[index - 1];
                        array[index - 1] = temp;

                        index = lastSorted;
                        lastSorted--;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Name: {Name}, Surname: {Surname}, Total_score: {TotalScore}");
            }
        }
    }
}
