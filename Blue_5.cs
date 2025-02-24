using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_4;
using static Lab_6.Blue_5;

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
                if (_place == 0)
                {
                    _place = place;
                }
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Место: {_place}");
            }
        }
        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
            }

            public int SummaryScore
            {
                get
                {
                    int score = 0;
                    foreach (var sportsman in _sportsmen)
                    {
                        switch (sportsman.Place)
                        {
                            case 1:
                                score += 5;
                                break;
                            case 2:
                                score += 4;
                                break;
                            case 3:
                                score += 3;
                                break;
                            case 4:
                                score += 2;
                                break;
                            case 5:
                                score += 1;
                                break;
                            default:
                                score += 0;
                                break;
                        }
                    }
                    return score;
                }
            }
            public int TopPlace
            {
                get
                {
                    int topPlace = int.MaxValue;
                    foreach (var sportsman in _sportsmen)
                    {
                        if (sportsman.Place < topPlace)
                        {
                            topPlace = sportsman.Place;
                        }
                    }
                    return topPlace;
                }
            }
            public void Add(Sportsman sportsman)
            {
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                foreach (var sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }
           
            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0) { return;}
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (ShouldSwap(teams[j], teams[j + 1]))
                        {                            
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
            private static bool ShouldSwap(Team team1, Team team2)
            {
                if (team1.SummaryScore != team2.SummaryScore)
                {
                    return team1.SummaryScore < team2.SummaryScore;
                }
                return team1.TopPlace > team2.TopPlace;
            }
            public void Print()
            {
                Console.WriteLine($"Команда: {Name}");
                foreach (var sportsman in _sportsmen)
                {
                    sportsman.Print();
                }
                Console.WriteLine($"Суммарный балл: {SummaryScore}, Наивысшее место: {TopPlace}");
            }
        }
    }
}

