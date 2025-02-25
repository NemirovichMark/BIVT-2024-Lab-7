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
                _scores = new int[] { };
            }

            public void PlayMatch(int result)
            {
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
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;
                    Team[] copy = new Team[_teams.Length];
                    Array.Copy(_teams, copy, copy.Length);
                    return copy;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[0];
            }

            public void Add(Team team)
            {
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

            public void Sort()
            {
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

                int i = 0;
                int j = 0;
                int k = 0;
                while(i < group1.Teams.Length && j < group2.Teams.Length && k < size)
        {
                    if (group1.Teams[i].TotalScore > group2.Teams[j].TotalScore)
                    {
                        finals.Add(group1.Teams[i++]);
                        k++;
                    }
                    else
                    {
                        finals.Add(group2.Teams[j++]);
                        k++;
                    }
                }

                while (i < group1.Teams.Length && k < size)
                {
                    finals.Add(group1.Teams[i++]);
                    k++;
                }

                while (j < group2.Teams.Length && k < size)
                {
                    finals.Add(group2.Teams[j++]);
                    k++;
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
