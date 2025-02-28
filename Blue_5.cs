using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0; 
            }

            public void SetPlace(int place)
            {
                if (_place != 0) 
                {
                    Console.WriteLine("Место уже установлено");
                    return;
                }

                if (place < 1 || place > 18)
                {
                    Console.WriteLine("Некорректное значение места");
                    return;
                }

                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"Спортсмен: {Name} {Surname}, Место: {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _count;

            public string Name => _name;

            public Sportsman[] Sportsmen => _sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;

                    int score = 0;

                    foreach (var sportsman in _sportsmen)
                    {
                        switch (sportsman.Place)
                        {
                            case 1: score += 5; break;
                            case 2: score += 4; break;
                            case 3: score += 3; break;
                            case 4: score += 2; break;
                            case 5: score += 1; break;
                            default: break;
                        }
                    }

                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;

                    int topPlace = int.MaxValue;
                    bool hasPlace = false;

                    foreach (var sportsman in _sportsmen)
                    {
                        if (sportsman.Place > 0 && sportsman.Place < topPlace)
                        {
                            topPlace = sportsman.Place;
                            hasPlace = true;
                        }
                    }

                    return hasPlace ? topPlace : 0;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null)
                {
                    _sportsmen = new Sportsman[6];
                }

                if (_count < 6)
                {
                    _sportsmen[_count] = sportsman;
                    _count++;
                }
                else
                {
                    Console.WriteLine("Команда уже заполнена");
                }
            }

            public void Add(Sportsman[] sportsmen)
            {
                foreach (var sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {SummaryScore} {TopPlace}");
            }


            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore
                            || (teams[j].SummaryScore == teams[j + 1].SummaryScore &&
                                teams[j].TopPlace > teams[j + 1].TopPlace))
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}