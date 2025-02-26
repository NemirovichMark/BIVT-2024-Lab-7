using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (_scores == null) return null;
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
                    int sum = 0;
                    for(int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                int[] arr = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    arr[i] = _scores[i];
                }
                arr[arr.Length - 1] = result;
                _scores = arr;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} - {TotalScore}");
            }

        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;

            public string Name => _name;
            public Team[] Teams => _teams;
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
            }

            public void Add(Team team)
            {
                if (_teams == null || _teams.Length == 0) return;
                if(_teams.Length < 12)
                {
                    Team[] arr = new Team[_teams.Length + 1];
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        arr[i] = _teams[i];
                    }
                    arr[arr.Length - 1] = team;
                    _teams = arr;
                }
            }

            public void Add(Team[] team)
            {
                if (_teams == null || team == null) return;
                 for(int i = 0; i < team.Length; i++)
                {
                    Add(team[i]);
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
                group1.Sort();
                group2.Sort();

                Group finals = new Group("Финалисты");

                int halfSize = size / 2;

                for (int i = 0; i < halfSize && i < group1.Teams.Length; i++)
                {
                    finals.Add(group1.Teams[i]);
                }

                for (int i = 0; i < halfSize && i < group2.Teams.Length; i++)
                {
                    finals.Add(group2.Teams[i]);
                }

                if (size % 2 != 0)
                {
                    if (group1.Teams.Length > halfSize && group2.Teams.Length > halfSize)
                    {
                        if (group1.Teams[halfSize].TotalScore > group2.Teams[halfSize].TotalScore)
                        {
                            finals.Add(group1.Teams[halfSize]);
                        }
                        else
                        {
                            finals.Add(group2.Teams[halfSize]);
                        }
                    }
                    else if (group1.Teams.Length > halfSize)
                    {
                        finals.Add(group1.Teams[halfSize]);
                    }
                    else if (group2.Teams.Length > halfSize)
                    {
                        finals.Add(group2.Teams[halfSize]);
                    }
                }

                return finals;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                foreach (var team in _teams)
                {
                    team.Print();
                }
            }

        
        }
    }
}
