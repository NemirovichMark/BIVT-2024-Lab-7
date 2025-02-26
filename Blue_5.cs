using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {public struct Sportsman
    {
        //поля
        private string name;
        private string surname;
        private int place;

        // свойства 
        public string Name => name;
        public string Surname => surname;
        public int Place => place;

        // Конструктор
        public Sportsman(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.place = 0;
        }

        // Методы
        public void SetPlace(int place)
        {
            if (this.place == 0) 
            {
                this.place = place;
            }
            else
            {
                Console.WriteLine($"Место для {Name} {Surname} уже установлено.");
            }
        }

        public void Print()
        {
            Console.WriteLine($"{Name} {Surname} {Place}");
        }
    }

    public struct Team
    {
        //поля
        private string name;
        private Sportsman[] sportsmen;

        //свойства 
        public string Name => name;
        public Sportsman[] Sportsmen => sportsmen;

        public int SummaryScore
        {
            get
            {
                int total = 0;
                foreach (var sportsman in sportsmen)
                {
                    switch (sportsman.Place)
                    {
                        case 1: total += 5; break;
                        case 2: total += 4; break;
                        case 3: total += 3; break;
                        case 4: total += 2; break;
                        case 5: total += 1; break;
                        default: total += 0; break;
                    }
                }
                return total;
            }
        }

        public int TopPlace
        {
            get
            {
                int top = int.MaxValue;
                foreach (var sportsman in sportsmen)
                {
                    if (sportsman.Place < top && sportsman.Place != 0)
                    {
                        top = sportsman.Place;
                    }
                }
                return top == int.MaxValue ? 0 : top;
            }
        }

        // Конструктор
        public Team(string name)
        {
            this.name = name;
            this.sportsmen = new Sportsman[0]; 
        }
        // Метод
        public void Add(Sportsman sportsman)
        {
            Array.Resize(ref sportsmen, sportsmen.Length + 1);
            sportsmen[sportsmen.Length - 1] = sportsman;
        }

        public void Add(params Sportsman[] newSportsmen)
        {
            foreach (var sportsman in newSportsmen)
            {
                Add(sportsman);
            }
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
            Console.WriteLine($"{Name}");
            foreach (var sportsman in sportsmen)
            {
                sportsman.Print();
            }
            Console.WriteLine();
        }
    }
}
}
