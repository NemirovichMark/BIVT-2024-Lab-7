using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null)
                    {
                        return null;
                    }
                    int[] copy = new int[_scores.Length];
                    Array.Copy(_scores, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;

                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null)
                {
                    return;
                }

                int[] newScores = new int[_scores.Length + 1];

                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }

            public void Print()
            {
                Console.Write(Name);
                Console.Write(" ");
                Console.WriteLine(TotalScore);
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _ind;

            public string Name => _name;
            public Team[] Teams => _teams;


            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _ind = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null)
                {
                    return;
                }

                if (_ind < _teams.Length)
                {
                    _teams[_ind] = team;
                    _ind++;
                }
            }

            public void Add(Team[] teams)
            {
                if (_teams == null || teams.Length == 0 || teams == null) return;

                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }

            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;

                for (int i = 0; i < _teams.Length - 1; i++)
                {
                    for (int j = 0; j < _teams.Length - 1 - i; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            Team temp = _teams[j];
                            _teams[j] = _teams[j + 1];
                            _teams[j + 1] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int i = 0; int j = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                    {
                        result.Add(group1.Teams[i++]);
                    }
                    else
                    {
                        result.Add(group2.Teams[j++]);
                    }
                }
                while (i < size / 2)
                {
                    result.Add(group1.Teams[i++]);
                }
                while (j < size / 2)
                {
                    result.Add(group2.Teams[j++]);
                }
                return result;
            }


            public void Print()
            {
                Console.WriteLine(_name);

                if (_teams != null && _teams.Length > 0)
                {
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        _teams[i].Print();
                    }
                }
            }
        }
    }
}