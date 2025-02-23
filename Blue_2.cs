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
            private int[,] _votes;

            public string Name => _name;

            public string Surname => _surname;

            public int[,] Votes
            {
                get
                {
                    if (_votes == null) return null;
                    int[,] copy = new int[_votes.GetLength(0), _votes.GetLength(1)];
                    Array.Copy(_votes, copy, _votes.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_votes == null) return 0;
                    int score = 0;
                    for (int i = 0; i < _votes.GetLength(0); i++) for (int j = 0; j < _votes.GetLength(1); j++) score += _votes[i, j];
                    return score;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = new int[2, 5];
            }

            public void Jump(int[] result)
            {
                if ((_votes == null) || (result == null) || (result.Length != _votes.GetLength(1))) return;
                for (int i = 0; i < _votes.GetLength(0); i++)
                {
                    bool skip = false;
                    for (int j = 0; j < _votes.GetLength(1); j++)
                    {
                        if (_votes[i, j] != 0)
                        {
                            skip = true;
                            break;
                        }
                    }
                    if (skip) continue;
                    for (int j = 0; j < _votes.GetLength(1); j++)
                    {
                        _votes[i, j] = result[j];
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
