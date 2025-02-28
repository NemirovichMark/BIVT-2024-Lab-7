using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

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
                    if (_scores == null || _scores.Length == 0) return 0;
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
                int[] newScores = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[_scores.Length] = result;
                _scores = newScores;
            }

            public void Print()
            {
                Console.WriteLine($"{Name}: {TotalScore}");
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
               
                if (_ind >= _teams.Length)
                {
                    Console.WriteLine("Группа уже заполнена");
                    return;
                }

                _teams[_ind] = team;
                _ind++;
            }

            public void Add(Team[] teams)
            {
                
                if (_ind + teams.Length > _teams.Length)
                {
                    Console.WriteLine("Недостаточно места для добавления всех команд.");
                    return;
                }

                
                for (int i = 0; i < teams.Length; i++)
                {
                    Add(teams[i]);
                }
            }

            public void Sort()
            {
                if (_teams == null || _teams.Length == 0) return;

                for (int i = 0; i < _ind - 1; i++)
                {
                    for (int j = 0; j < _ind - i - 1; j++)
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
                int i = 0, j = 0;

                while (i < group1._ind && j < group2._ind && result._ind < size)
                {
                    if (group1._teams[i].TotalScore >= group2._teams[j].TotalScore)
                    {
                        result.Add(group1._teams[i++]);
                    }
                    else
                    {
                        result.Add(group2._teams[j++]);
                    }
                }

                while (i < group1._ind && result._ind < size)
                {
                    result.Add(group1._teams[i++]);
                }

                while (j < group2._ind && result._ind < size)
                {
                    result.Add(group2._teams[j++]);
                }

                return result;
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine("Команды:");

                for (int i = 0; i < _ind; i++)
                {
                    Console.WriteLine($"Команда {i + 1}:");
                    _teams[i].Print();
                }
            }
        }
    }
}