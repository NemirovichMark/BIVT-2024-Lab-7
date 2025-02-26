using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_6;

namespace ЛР_6
{
    public class Blue__5
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
                _place = -1;
            }

            public void SetPlace(int place)
            {

                if (place < 1 || place > 18)
                {
                    return;
                }
                _place = place;
            }
        }

        public struct Team
        {
            
            private string _name;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            
            public int SummaryScore
            {
                get
                {
                    int score = 0;

                    foreach (var sportsman in _sportsmen)
                    {
                        if (sportsman.Place == -1)
                            continue;

                        switch (sportsman.Place)
                        {
                            case 1: score += 5; break;
                            case 2: score += 4; break;
                            case 3: score += 3; break;
                            case 4: score += 2; break;
                            case 5: score += 1; break;
                        }
                    }

                    return score;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null || _sportsmen.Length == 0)
                    {
                        return int.MaxValue;
                    }

                    int topPlace = int.MaxValue;

                    foreach (var sportsman in _sportsmen)
                    {
                        if (sportsman.Place != -1 && sportsman.Place < topPlace)
                        {
                            topPlace = sportsman.Place;
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
                var newSportsmen = new Sportsman[_sportsmen.Length + 1];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    newSportsmen[i] = _sportsmen[i];
                }
                newSportsmen[_sportsmen.Length] = sportsman;
                _sportsmen = newSportsmen;
            }

            
            public void Add(Sportsman[] sportsmen)
            {
                var newSportsmen = new Sportsman[_sportsmen.Length + sportsmen.Length];
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    newSportsmen[i] = _sportsmen[i];
                }
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    newSportsmen[_sportsmen.Length + i] = sportsmen[i];
                }
                _sportsmen = newSportsmen;
            }

            
            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = i + 1; j < teams.Length; j++)
                    {
                        
                        if (teams[i].SummaryScore < teams[j].SummaryScore ||
                            (teams[i].SummaryScore == teams[j].SummaryScore && teams[i].TopPlace > teams[j].TopPlace))
                        {
                            Team temp = teams[i];
                            teams[i] = teams[j];
                            teams[j] = temp;
                        }
                    }
                }
            }

            
            public void Print()
            {
                Console.WriteLine($"{Name} {SummaryScore} {TopPlace}");
            }
        }
    }
}
