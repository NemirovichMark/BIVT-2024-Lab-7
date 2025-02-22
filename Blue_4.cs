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
            private int[] _score;

            public string Name=>_name;
            public int[] Score
            {
                get
                {
                    if(_score==null) return default(int[]);
                    int[] res = new int[_score.Length];
                    for(int i =0; i < _score.Length; i++) res[i] = _score[i];
                    return res;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_score == null) return 0;
                    int sum = 0;
                    for(int i = 0; i < _score.Length; i++) sum += _score[i];
                    return sum;
                }
            }

            public Team(string name)
            {
                _name = name;
                _score = new int[1];
            }

            public void PlayMatch(int result)
            {
                if(_score == null) return;
                int[] newmas = new int[_score.Length+1];
                for(int i = 0;i < _score.Length; i++)
                {
                    if(i==_score.Length)
                        newmas[i] = result;
                    else
                        newmas[i] = _score[i];

                }
            }
            public void Print()
            {
                Console.WriteLine("{0,-20}", Name);
            }

        }


        public struct Group
        {
            private string _name;
            private Team[] _teams;

            public string Name => _name;
            public Team[] Score
            {
                get
                {
                    if (_teams == null) return default(Team[]);
                    Team[] res = new Team[_teams.Length];
                    for (int i = 0; i < _teams.Length; i++) res[i] = _teams[i];
                    return res;
                }
            }
            public Group(string name)
            {
                _name = name;
                _teams = new Team[1];
            }

            public void Add(Team team)
            {
                if (_teams == null) return;
                Team[] newTeam = new Team[_teams.Length+1];
                for(int i = 0; i < _teams.Length;i++)
                {
                    if(i==_teams.Length) newTeam[i] = team;
                    else newTeam[i] = _teams[i];
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || teams==null) return;
                Team[] newTeams = new Team[_teams.Length+teams.Length];
                for (int i = 0; i < _teams.Length; i++) { 
                    if(i==_teams.Length) newTeams[i] = teams[i-_teams.Length];
                    else newTeams[i] = _teams[i];
                }
            }
            public void Sort() {

                if (_teams == null) return;
                if (_teams.Length != 1)
                {
                    for (int i = 1, j = 2; i < _teams.Length;)
                    {
                        if (i == 0 || _teams[i].TotalScore <= _teams[i - 1].TotalScore)
                        {
                            i = j;
                            j++;
                        }
                        else
                        {
                            (_teams[i], _teams[i - 1]) = (_teams[i - 1], _teams[i]);
                            i--;
                        }
                    }

                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group group = new Group("Финалисты");
                int count = 0;
                int index1 = 0, index2 = 0;

                while (count < size && index1 < group1._teams.Length && index2 < group2._teams.Length)
                {
                    if (group1._teams[index1].TotalScore >= group2._teams[index2].TotalScore)
                    {
                        group.Add(group1._teams[index1]);
                        index1++;
                    }
                    else
                    {
                        group.Add(group2._teams[index2]);
                        index2++;
                    }
                    count++;
                }

                while (count < size && index1 < group1._teams.Length)
                {
                    group.Add(group1._teams[index1]);
                    index1++;
                    count++;
                }

                while (count < size && index2 < group2._teams.Length)
                {
                    group.Add(group2._teams[index2]);
                    index2++;
                    count++;
                }

                return group;
            }

            public void Print()
            {
                Console.WriteLine("{0,-20}", Name);
            }
        }
    }
}
