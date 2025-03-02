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
                    if (_sportsmen == null || _count == 0)
                        return 0;

                    int totalScore = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        switch (_sportsmen[i].Place)
                        {
                            case 1: totalScore += 5; break;
                            case 2: totalScore += 4; break;
                            case 3: totalScore += 3; break;
                            case 4: totalScore += 2; break;
                            case 5: totalScore += 1; break;
                            default: break;
                        }
                    }
                    return totalScore;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _count == 0)
                        return 18;

                    int topPlace = 18;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place < topPlace && _sportsmen[i].Place != 0)
                        {
                            topPlace = _sportsmen[i].Place;
                        }
                    }
                    return topPlace;
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
                if (sportsmen == null || sportsmen.Length == 0)
                    return;

                foreach (var sportsman in sportsmen)
                {
                    if (_count < 6)
                    {
                        _sportsmen[_count] = sportsman;
                        _count++;
                    }
                    else
                    {
                        Console.WriteLine("Команда уже заполнена");
                        break;
                    }
                }
            }

            public static void Print(Team[] teams)
            {
                foreach (var team in teams)
                {
                    Console.WriteLine($"{team.Name} {team.SummaryScore} {team.TopPlace}");
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0)
                    return;

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
