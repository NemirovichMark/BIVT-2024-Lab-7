using System;
using System.Collections.Generic;
using System.Linq;
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
            private bool _placechanged;

            public string Name => _name;

            public string Surname => _surname;

            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 100;
                _placechanged = false;
            }

            public void SetPlace(int place)
            {
                if (_placechanged) return;
                _place = place;
                _placechanged = true;
            }

            public void Print()
            {
                Console.WriteLine("{0} {1}\t{2}", _name, _surname, _place);
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
                    Sportsman[] copy = new Sportsman[_sportsmen.Length];
                    Array.Copy(_sportsmen, copy, _sportsmen.Length);
                    return copy;
                }
            }

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int scoresum = 0, score = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        score = 6 - _sportsmen[i].Place;
                        if (score > 0)
                        {
                            scoresum += score;
                        }
                    }
                    return scoresum;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int mn = int.MaxValue;
                    for (int i = 0; i < _sportsmen.Length; i++) if (_sportsmen[i].Place < mn) mn = _sportsmen[i].Place;
                    return mn;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[0];
            }

            public void Add(Sportsman sportsman)
            {
                if (sportsman.Place == 100) return;
                Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                _sportsmen[_sportsmen.Length - 1] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (sportsmen == null) return;
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    if (sportsmen[i].Place == 100) return;
                    Array.Resize(ref _sportsmen, _sportsmen.Length + 1);
                    _sportsmen[_sportsmen.Length - 1] = sportsmen[i];
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if ((teams[j].SummaryScore < teams[j + 1].SummaryScore) 
                            || ((teams[j].SummaryScore == teams[j + 1].SummaryScore) && (teams[j]).TopPlace > teams[j + 1].TopPlace))
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine("{0}  \t {1} {2}", _name, SummaryScore, TopPlace);
            }
        }
    }
}
