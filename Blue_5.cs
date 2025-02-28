using System;


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
                else _place = place;
            }

            public void Print()
            {
                Console.Write("{0,-20} {1,-20} {2, -10}", Name, Surname,Place);
            }
        }

        public struct Team
        {
            private string _name;
            private Sportsman[] _sportsmen;
            private int _cnt;

            public string Name => _name;
            public Sportsman[] Sportsmen
            {
                get
                {
                    if (_sportsmen == null) return null;
                    Sportsman[] sporty = new Sportsman[Sportsmen.Length];
                    for (int i = 0; i < Sportsmen.Length; i++)
                        sporty[i] = _sportsmen[i];
                    return sporty;
                }
            }

            public int SummaryScore
            {
                get
                {
                    if(_sportsmen == null) return 0;
                    int sum = 0;
                    foreach (var sportsmen in _sportsmen)
                    {
                        switch (sportsmen.Place)
                        {
                            case 1: sum += 5; break;
                            case 2: sum += 4; break;
                            case 3: sum += 3; break;
                            case 4: sum += 2; break;
                            case 5: sum += 1; break;
                            default: sum += 0; break;
                        }

                    }
                        
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int top = int.MaxValue;
                    foreach(var sportsmen in _sportsmen)
                    {
                        if(sportsmen.Place<top)
                            top = sportsmen.Place;
                    }
                    return top;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _cnt = 0;
            }
            public void Add(Sportsman sportsman)
            {

                if (_sportsmen == null)                
                    _sportsmen = new Sportsman[6];
                
                if (_cnt < _sportsmen.Length)                
                    _sportsmen[_cnt++] = sportsman;
                                 
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || sportsmen == null) return;
               
                for (int i = 0; i < sportsmen.Length; i++)
                {
                    Add(sportsmen[i]);
                }
              
            }
            public static void Sort(Team[] teams)
            {

                if (teams == null) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j + 1].SummaryScore > teams[j].SummaryScore)
                        {
                            (teams[j + 1], teams[j]) = (teams[j], teams[j + 1]);
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
                Console.WriteLine("{0,-20}", Name);
            }

        }
    }
}
