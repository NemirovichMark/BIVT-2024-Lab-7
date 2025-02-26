using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_6;

namespace ЛР_6
{
    public class Blue__4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores => _scores;

            public int TotalScore
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                        return 0;

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
                    _scores = new int[0];
                }

               
                int[] newScores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[_scores.Length] = result;
                _scores = newScores;
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
                _teams = new Team[0]; 
            }

            public void Add(Team team)
            {
               
                if (_teams.Length >= 12)
                { 
                    return;
                }

                Team[] newTeams = new Team[_teams.Length + 1];
                for (int i = 0; i < _teams.Length; i++)
                {
                    newTeams[i] = _teams[i];
                }
                newTeams[_teams.Length] = team;
                _teams = newTeams;
            }

            public void Add(Team[] teams)
            {
                
                if (_teams.Length + teams.Length > 12)
                {
                    return;
                }

                Team[] newTeams = new Team[_teams.Length + teams.Length];
                for (int i = 0; i < _teams.Length; i++)
                {
                    newTeams[i] = _teams[i];
                }
                for (int i = 0; i < teams.Length; i++)
                {
                    newTeams[_teams.Length + i] = teams[i];
                }
                _teams = newTeams;
            }

            public void Sort()
            {
                if (_teams == null || _teams.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = i + 1; j < _teams.Length; j++)
                    {
                        if (_teams[i].TotalScore < _teams[j].TotalScore)
                        {
                            Team temp = _teams[i];
                            _teams[i] = _teams[j];
                            _teams[j] = temp;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                
                Team[] mergedTeams = new Team[size];
                int index = 0;
                int i = 0, j = 0;

                
                while (index < size && i < group1._teams.Length && j < group2._teams.Length)
                {
                    if (group1._teams[i].TotalScore > group2._teams[j].TotalScore)
                    {
                        mergedTeams[index] = group1._teams[i];
                        i++;
                    }
                    else
                    {
                        mergedTeams[index] = group2._teams[j];
                        j++;
                    }
                    index++;
                }
                                
                while (index < size && i < group1._teams.Length)
                {
                    mergedTeams[index] = group1._teams[i];
                    i++;
                    index++;
                }

                while (index < size && j < group2._teams.Length)
                {
                    mergedTeams[index] = group2._teams[j];
                    j++;
                    index++;
                }

                
                Group finalGroup = new Group("Финалисты");
                finalGroup.Add(mergedTeams);
                return finalGroup;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}");
                foreach (var team in _teams)
                {
                    Console.WriteLine($"{team.Name} {team.TotalScore}");
                }
            }
        }
    }
}
