using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            //свойства
            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] copyArray = new int[_scores.Length];
                    Array.Copy(_scores, copyArray, copyArray.Length);
                    return copyArray;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                    {
                        return 0;
                    }
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                    {
                        total += _scores[i];
                    }
                    return total;
                }
            }

            //конструктор
            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            //метод
            public void PlayMatch(int result)
            {
                if (_scores == null) { return; }
                Array.Resize(ref _scores, _scores.Length + 1);
                _scores[_scores.Length - 1] = result;
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {Name}, Очки: {string.Join(", ", Scores)}, Всего очков: {TotalScore}");
            }

        }

        public struct Group
        {
            private string _name;        //название группы
            private Team[] _teams;       //массив команд (где каждый элемент является объектом типа Team!)
            private int _counterTeams;

            public string Name => _name;
            public Team[] Teams => _teams;

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];

                _counterTeams = 0;
            }

            public void Add(ref Team team)
            {
                if (_teams == null) return;
                if (_counterTeams < 12)
                {
                    _teams[_counterTeams++] = team;
                }
            }
            public void Add(params Team[] teams)
            {
                if (_teams == null || teams == null) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    Add(ref teams[i]); // Передача элемента массива по ссылке
                }
            }
            public void Sort()
            {
                if (_teams == null) return;
                for (int i = 0; i < _counterTeams - 1; i++)
                {
                    for (int j = 0; j < _counterTeams - 1 - i; j++)
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

                if (group1.Teams == null || group2.Teams == null) return default(Group);

                int index1 = 0;
                int index2 = 0;

                // Объединяем команды до достижения максимального размера
                while (index1 < size / 2 && index2 < size / 2)
                {
                    if (group1.Teams[index1].TotalScore >= group2.Teams[index2].TotalScore)
                    {
                        finalists.Add(group1.Teams[index1]);
                        index1++;
                    }
                    else
                    {
                        finalists.Add(group2.Teams[index2]);
                        index2++;
                    }
                }

                while (index1 < size / 2)
                {
                    finalists.Add(group1.Teams[index1++]);
                }

                while (index2 < size / 2)
                {
                    finalists.Add(group2.Teams[index2++]);
                }
                return finalists;
            }
            public void Print()
            {
                Console.WriteLine($"Группа: {_name}");
                Console.WriteLine("Команды:");
                for (int i = 0; i < _counterTeams; i++) // Используем _counterTeams вместо _teams.Length
                {
                    _teams[i].Print();
                }
            }

        }
    }
    }