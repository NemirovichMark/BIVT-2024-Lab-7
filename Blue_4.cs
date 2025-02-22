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
                    Array.Copy(_scores, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
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
                int newSize = _scores.Length + 1;
                int[] newScores = new int[newSize];

                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }

                newScores[newSize - 1] = result; 
                _scores = newScores; 
            }
    
            public void Print()
            {
                Console.WriteLine($"Команда: {_name}");
                Console.WriteLine("Результаты матчей:");

                if (_scores != null && _scores.Length > 0)
                {
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        Console.WriteLine($"Матч {i + 1}: {_scores[i]} очков");
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о матчах.");
                }
                Console.WriteLine($"Общее количество очков: {TotalScore}");
                
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
                if (_teams == null)
                    return;

                if (_teams.Length < 12)
                {
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        if (_teams[i].Name == null)
                        {
                            _teams[i] = team;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("В группе уже 12 команд, добавление невозможно.");
                }
            }
            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++) 
                {
                    Add(teams[i]); 
                }
            }
            public void Sort()
            {
                if (_teams == null)
                    return;

                int n = _teams.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
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
                Group finalists = new Group("Финалисты");
                int totalTeams = 0;

                for (int i = 0; i < group1.Teams.Length; i++)
                {
                    if (totalTeams < size)
                    {
                        finalists.Add(group1.Teams[i]);
                        totalTeams++;
                    }
                }
                for (int i = 0; i < group2.Teams.Length; i++)
                {
                    if (totalTeams < size)
                    {
                        finalists.Add(group2.Teams[i]);
                        totalTeams++;
                    }
                }

                return finalists; 
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine("Команды:");

                if (_teams != null && _teams.Length > 0)
                {
                    for (int i = 0; i < _teams.Length; i++)
                    {
                        Console.WriteLine($"Команда {i + 1}");
                        _teams[i].Print(); 
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о командах.");
                }
            }
        }
    }
}
