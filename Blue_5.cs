using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Surname
            {
                get
                {
                    return _surname;
                }
            }
            public int Place
            {
                get
                {
                    return _place;
                }
            }

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place != 0) return;
                _place = place;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - {Place}");
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    return _sportsmen;
                }
            }

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int scores = 0;
                    foreach(var sportsman in _sportsmen)
                    {
                        switch (sportsman.Place)
                        {
                            case 1:
                                scores += 5;
                                break;
                            case 2:
                                scores += 4;
                                break;
                            case 3:
                                scores += 3;
                                break;
                            case 4:
                                scores += 2;
                                break;
                            case 5:
                                scores += 1;
                                break;
                            default:
                                break;
                        }
                    }
                    return scores;
                }

            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0) return 0;
                    int top = _sportsmen[0].Place;
                    foreach(var sportsman in _sportsmen)
                    {
                        if(sportsman.Place < top)
                        {
                            top = sportsman.Place;
                        }
                    }
                    return top;
                }
            }


            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public void Add(Sportsman sportsman)
            {
                if(_sportsmen == null)
                {
                    return;
                }
                Sportsman[] Arr = new Sportsman[_sportsmen.Length + 1];
                for(int i = 0; i < _sportsmen.Length; i++)
                {
                    Arr[i] = _sportsmen[i];
                }
                Arr[_sportsmen.Length] = sportsman;
                _sportsmen = Arr;
            }

            public void Add(params Sportsman[] sportsmen)
            {
                foreach(var sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }


            public static void Sort(Team[] teams)
            {
                if (teams == null) return;
                int n = teams.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
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
            }

        }
    }
}
