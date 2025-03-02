using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                if (_place != 0) return;
                _place = place;
            }

            public void Print()
            {
            
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
                    if (_sportsmen == null || _sportsmen.Length == 0)
                        return 0;

                    int total = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        switch (_sportsmen[i].Place)
                        {
                            case 1: total += 5; break;
                            case 2: total += 4; break;
                            case 3: total += 3; break;
                            case 4: total += 2; break;
                            case 5: total += 1; break;
                            default: break;
                        }
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0)
                        return 0;

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
            }

            public void Add(params Sportsman[] newSportsmen)
            {
                if (_sportsmen == null) return;

                foreach (var sportsman in newSportsmen)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null) return;

                Array.Sort(teams, (x, y) =>
                {
                    int scoreComparison = y.SummaryScore.CompareTo(x.SummaryScore);

                    if (scoreComparison != 0) return scoreComparison;
                    

                    return x.TopPlace.CompareTo(y.TopPlace);
                }          );
            }


            public void Print() { }
        }
    }
}
