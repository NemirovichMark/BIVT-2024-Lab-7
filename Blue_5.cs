using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{

    public class Blue_5
    {
        public struct Sportsman
        {

            private string name;
            private string surname;
            private int place;
            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Place: ");
                Console.WriteLine(place);
            }

            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }

            public int Place
            {
                get
                {
                    if (place == 0)
                        return 0;
                    return place;
                }
            }


            public Sportsman(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.place = 0;
            }


            public void SetPlace(int place)
            {
                this.place = place;
            }
        }

        public struct Team
        {

            private string name;
            private Sportsman[] sportsmen;

            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                for (int j = 0; j < sportsmen.Length; j++)
                {
                    sportsmen[j].Print();

                }
            }

            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public Sportsman[] Sportsmen
            {
                get
                {
                    if (sportsmen == null)
                        return null;
                    return sportsmen;
                }
            }


            public int SummaryScore
            {
                get
                {
                    if (sportsmen == null)
                        return 0;

                    int total = 0;
                    foreach (var sportsman in sportsmen)
                    {
                        if (sportsman.Place == 1)
                        {
                            total += 5;
                        }
                        else if (sportsman.Place == 2)
                        {
                            total += 4;
                        }
                        else if (sportsman.Place == 3)
                        {
                            total += 3;
                        }
                        else if (sportsman.Place == 4)
                        {
                            total += 2;
                        }
                        else if (sportsman.Place == 5)
                        {
                            total += 1;
                        }
                        else
                        {
                            total += 0;
                        }
                    }
                    return total;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (sportsmen == null)
                        return 0;

                    int topPlace = 18;
                    
                    foreach (var sportsman in sportsmen)
                    {
                        if (sportsman.Place < topPlace)
                        {
                            if(sportsman.Place == 0)
                            {
                                    continue;
                            }
                            topPlace = sportsman.Place;
                        }
                    }
                    return topPlace;
                }
            }


            public Team(string name)
            {
                this.name = name;
                this.sportsmen = new Sportsman[6];
            }

            public void Add(Sportsman sportsman)
            {
                if (sportsmen == null)
                    return;

                for (int i = 0; i < sportsmen.Length; i++)
                {
                    if (sportsmen[i].Name == null)
                    {
                        sportsmen[i] = sportsman;
                        break;
                    }
                }
            }

            public void Add(params Sportsman[] newSportsmen)
            {
                if (sportsmen == null)
                    return ;

                foreach (var sportsman in newSportsmen)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null)
                    return;

                Array.Sort(teams, (x, y) =>
                {
                    int scoreComparison = y.SummaryScore.CompareTo(x.SummaryScore);
                    if (scoreComparison != 0)
                        return scoreComparison;
                    return x.TopPlace.CompareTo(y.TopPlace);
                });
            }
        }
    }
}
