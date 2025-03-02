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
                _scores = new int[0];
            }

            //остальные методы
            public void PlayMatch(int result)
            {
                if (_scores == null) return;
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
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
            public Team[] Teams { get { return _teams; } }

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
                if (_teams == null || _count >= _teams.Length) return;
                if (_count < _teams.Length)
                {
                    _teams[_count++] = teams;
                }
            }
            public void Add(Team[] teams)
            {
                if (_teams == null || _count >= _teams.Length) return;
                for (int i = 0; i < _teams.Length; i++)
                {
                    if (_count >= _teams.Length) return;
                    if (_count < _teams.Length)
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
                while (i < size / 2 && j < size / 2)
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
                while (i < size / 2)
                {
                    merged.Add(group1._teams[i]);
                    i++;
                }
                while (j < size / 2)
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
