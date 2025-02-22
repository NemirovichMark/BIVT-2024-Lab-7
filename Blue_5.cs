using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_5
    {public struct Sportsman
    {
        // Приватные поля
        private string name;
        private string surname;
        private int place;

        // Публичные свойства только для чтения
        public string Name => name;
        public string Surname => surname;
        public int Place => place;

        // Конструктор
        public Sportsman(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.place = 0; // Изначально место не установлено
        }

        // Метод для установки места
        public void SetPlace(int place)
        {
            if (this.place == 0) // Место можно установить только один раз
            {
                this.place = place;
            }
            else
            {
                Console.WriteLine($"Место для {Name} {Surname} уже установлено.");
            }
        }

        // Метод для вывода информации об участнике
        public void Print()
        {
            Console.WriteLine($"{Name} {Surname} {Place}");
        }
    }

    public struct Team
    {
        // Приватные поля
        private string name;
        private Sportsman[] sportsmen;

        // Публичные свойства только для чтения
        public string Name => name;
        public Sportsman[] Sportsmen => sportsmen;

        // Публичное свойство для подсчета общего количества баллов
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

        // Публичное свойство для определения наивысшего места
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
            this.sportsmen = new Sportsman[0]; // Инициализируем пустой массив
        }

        // Метод для добавления одного участника
        public void Add(Sportsman sportsman)
        {
            Array.Resize(ref sportsmen, sportsmen.Length + 1);
            sportsmen[sportsmen.Length - 1] = sportsman;
        }

        // Метод для добавления нескольких участников
        public void Add(params Sportsman[] newSportsmen)
        {
            foreach (var sportsman in newSportsmen)
            {
                Add(sportsman);
            }
        }

        // Статический метод для сортировки команд
        public static void Sort(Team[] teams)
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = i + 1; j < teams.Length; j++)
                {
                    if (teams[i].SummaryScore < teams[j].SummaryScore ||
                        (teams[i].SummaryScore == teams[j].SummaryScore && teams[i].TopPlace > teams[j].TopPlace))
                    {
                        // Меняем местами команды
                        Team temp = teams[i];
                        teams[i] = teams[j];
                        teams[j] = temp;
                    }
                }
            }
        }

        // Метод для вывода информации о команде
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
