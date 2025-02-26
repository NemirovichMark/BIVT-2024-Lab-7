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
            private int _count;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public int SummaryScore
            {
                get
                {
                    int score = 0;
                    if (_sportsmen == null) return 0;
                    for (int i = 0; i < _count; i++)
                    {
                        switch (_sportsmen[i].Place)
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
                    for (int i = 0; i < _count; i++)
                    {
                        int currentPlace = _sportsmen[i].Place;                        
                        if (currentPlace == 0)
                        {
                            currentPlace = 18;
                        }
                        if (currentPlace < topPlace)
                        {
                            topPlace = currentPlace;
                        }
                    }
                    return topPlace == int.MaxValue ? 0 : topPlace;
                }
            }
            public void Add(Sportsman sportsman)
            {
                if (_count < _sportsmen.Length) // Проверяем, есть ли место в массиве
                {
                    _sportsmen[_count] = sportsman;
                    _count++;
                }
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
                for (int i = 0; i < _count; i++)
                {
                    _sportsmen[i].Print();
                }
                Console.WriteLine($"Суммарный балл: {SummaryScore}, Наивысшее место: {TopPlace}");
            }
        }
    }
}

