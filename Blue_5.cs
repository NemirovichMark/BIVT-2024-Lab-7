using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Blue_5;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman { 
            private string _name;
            private string _surname;
            private int _place;

            private bool _setted_place; // вводим вспомогательную переменную из-за невозможности использования readonly для переменной _place.

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname) { 
                _name = name;
                _surname = surname;
                _place = 0;
                _setted_place = false;
            }

            public void SetPlace(int place) {
                if (_setted_place == false)
                {
                    _place = place;
                    _setted_place = true;
                }
                else {
                    Console.WriteLine($"Этот спортсмен уже занял {_place} место.");
                }
            }

            public void Print() {
                Console.WriteLine($"{_name} {_surname} {_place}");
            }
        }

        public struct Team { 
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen {
                get {
                    if (_sportsmen == null) return null;
                    Sportsman[] newArr = new Sportsman[ _sportsmen.Length ];
                    Array.Copy(_sportsmen, newArr, _sportsmen.Length );
                    return newArr;
                }
            }

            public int SummaryScore {
                get {
                    if (_sportsmen == null) { return 0; }
                    int sum = 0;
                    foreach (Sportsman sportsman in _sportsmen) {
                        //sum += sportsman.Place;
                        if (5 - sportsman.Place + 1 > 0)
                        {
                            sum += 5 - sportsman.Place + 1;
                        }
                    }
                    return sum;
                }
            }

            public int TopPlace {
                get {
                    if (_sportsmen == null) { return 0; }
                    int maxi = -1;
                    foreach (Sportsman sportsman in _sportsmen) { 
                        maxi = Math.Max( maxi, sportsman.Place );
                    }
                    return maxi;
                }
            }

            public Team(string name) {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public void Add(Sportsman sportsman) {
                if (_sportsmen == null) return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] new_sportsmen) { 
                if (_sportsmen == null) return;
                int old_len = _sportsmen.Length;
                Array.Resize(ref _sportsmen, _sportsmen.Length + new_sportsmen.Length);
                for (int i = 0; i < new_sportsmen.Length; i++) {
                    _sportsmen[old_len + i] = new_sportsmen[i];
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = i; j < teams.Length; j++)
                    {
                        if (teams[i].SummaryScore < teams[j].SummaryScore)
                        {
                            Team tmp = teams[i];
                            teams[i] = teams[j];
                            teams[j] = tmp;
                        }
                    }
                }
                if (teams.Length >= 2)
                {
                    if (teams[0].SummaryScore == teams[1].SummaryScore)
                    {
                        int priority = 0;
                        foreach (Sportsman sportsman in teams[0].Sportsmen)
                        {
                            if (sportsman.Place == 1) { priority = 1; }
                        }
                        if (priority == 0)
                        {
                            foreach (Sportsman sportsman in teams[1].Sportsmen)
                            {
                                if (sportsman.Place == 1) { priority = 2; }
                            }
                        }
                        if (priority == 0 || priority == 1)
                        {
                            return;
                        }
                        Team tmp = teams[0];
                        teams[0] = teams[1];
                        teams[1] = tmp;
                    }
                }

            }

            public void Print() {
                Console.WriteLine($"{_name} {TopPlace} {SummaryScore}");
            }
        }

    }
}
