using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;
using static Lab_6.Blue_5;

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
                    Array.Copy(_scores, copy, _scores.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int score = 0;
                    for (int i = 0; i < _scores.Length; i++) score += _scores[i];
                    return score;
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
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine("{0}     \t{1}", _name, TotalScore);
            }
        }

        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _teamID;

            public string Name => _name;

            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _teamID = 0;
            }

            public void Add(Team team)
            {
                if ((_teams == null) || (_teamID >= 12)) return;
                _teams[_teamID] = team;
                _teamID++;
            }

            public void Add(Team[] teams)
            {
                if ((_teams == null) || (teams == null)) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    if (_teamID >= 12) return;
                    _teams[_teamID] = teams[i];
                    _teamID++;
                }
            }

            public void Sort()
            {
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
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
                Team[] team1 = group1.Teams;
                Team[] team2 = group2.Teams;
                Group finalists = new Group("Финалисты");
                if ((team1 == null) || (team2 == null)) return finalists;
                for (int i = 0; i < size; i++)
                {
                    if (i < team1.Length) finalists.Add(team1[i]);
                    if (i < team2.Length) finalists.Add(team2[i]);
                }
                finalists.Sort();
                return finalists;
            }

            public void Print()
            {
                for (int i = 0; i < _teams.Length; i++)
                {
                    _teams[i].Print();
                }
            }
        }
    }
}
