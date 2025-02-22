using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (_place != 0)
                {
                    Console.WriteLine("Место уже установлено.");
                }
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"Спортсмен: {_name} {_surname}, Место: {_place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public int[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    int[] copy = new int[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, copy.Length);
                    return copy;
                }
            }

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0)
                        return 0;

                    int totalScore = 0;
                    for (int i = 0; i < _sportsmen.Length; i++) 
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
                    if (_sportsmen == null)
                        return 0;

                    int topPlace = int.MaxValue;
                    for (int i = 0; i < _sportsmen.Length; i++) 
                    {
                        if (_sportsmen[i].Place < topPlace) 
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
                _sportsmen = new Sportsman[0]; 
            }

            public void Add(Sportsman sportsman)
            {
                Sportsman[] newSportsmen = new Sportsman[_sportsmen.Length + 1];

                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    newSportsmen[i] = _sportsmen[i];
                }

                newSportsmen[newSportsmen.Length - 1] = sportsman;
                _sportsmen = newSportsmen;
            }
            public void Add(Sportsman[] sportsmen)
            {
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Add(sportsmen[i]); 
                }
            }

            public void Print()
            {
                Console.WriteLine($"Команда: {_name}");
                Console.WriteLine($"Суммарный балл: {SummaryScore}");
                Console.WriteLine($"Наивысшее место: {TopPlace}");
                Console.WriteLine("Спортсмены:");

                if (_sportsmen != null && _sportsmen.Length > 0)
                {
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        _sportsmen[i].Print(); 
                    }
                }
                else
                {
                    Console.WriteLine("Нет данных о спортсменах.");
                }
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
                    if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                    {
                        Team temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                    }
                    else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                    {
                        if (teams[j].TopPlace > teams[j + 1].TopPlace)
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
