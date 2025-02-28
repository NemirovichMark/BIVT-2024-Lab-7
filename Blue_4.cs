using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            //поля
            private string _name;
            private int[] _scores;

            private int _count;

            //cвойства
            public string Name { get { return _name; } }
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] results = new int[_scores.Length];
                    int count = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        results[count++] = _scores[i];
                    }
                    return results;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        sum += _scores[i];
                    }
                    return sum;
                }
            }

            //конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[20];

                _count = 0;
            }

            //остальные методы
            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                _scores[_count] = result;
                _count++;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {TotalScore}");
            }
        }
        //другая структура
        public struct Group
        {
            //поля
            private string _name;
            private Team[] _teams;
            private int _count;

            //свойства
            public string Name { get { return _name; } }
            public Team[] Teams
            {
                get
                {
                    if (_teams == null) return null;
                    Team[] array = new Team[_teams.Length];
                    Array.Copy(_teams, array, array.Length);
                    return array;
                }
            }

            //конструктор
            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];

                _count = 0;
            }

            //остальные методы
            public void Add(Team teams)
            {
                if (_teams == null || _count >= 12) return;
                if (_count < 12)
                {
                    _teams[_count++] = teams;
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || _count >= 12) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    if (_count >= 12) return;
                    if (_count < 12)
                    {
                        _teams[_count++] = teams[i];
                    }
                }
            }
            
            public void Sort()
            {
                if (_teams == null) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    for (int j = 0; j < _teams.Length - i - 1; j++)
                    {
                        if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        {
                            (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                        }
                    }
                }
            }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group merged = new Group("Финалисты");
                int i = 0, j = 0;
                while (i < size && j < size)
                {
                    if (group1._teams[i].TotalScore >= group2._teams[j].TotalScore)
                    {
                        merged.Add(group1._teams[i]);
                        i++;
                    }
                    else
                    {
                        merged.Add(group2._teams[j]);
                        j++;
                    }
                }
                while (i < size)
                {
                    merged.Add(group1._teams[i]);
                    i++;
                }
                while (j < size)
                {
                    merged.Add(group2._teams[j]);
                    j++;
                }
                return merged;

            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Teams}");
            }
        }
    }
}
