using System;
using System.Dynamic;
using System.Linq;

namespace ConsoleApp1;

public class Blue_5
{
    public struct Sportsman {
        // поля
        private string _name;
        private string _surname;
        private int _place;
        private bool _flag = true;


        // свойства
        public string Name => _name;
        public string Surname => _surname;
        public int Place => _place;

        // конструктор
        public Sportsman(string name, string surname) {
            _name = name;
            _surname = surname;
            _place = 0;
            _flag = true;
        }
        // методы
        public void SetPlace(int place) {
            if (_flag) {
                _place = place;
                _flag = false;
            }
        }

        public void Print() {
            Console.WriteLine($"Спортсмен: {_name}, Место: {_place}");
        }
    }

    public struct Team
    {
        private string _name;
        private Sportsman[] _sportsmen;
        private int _count;

        // свойства
        public string Name => _name;
        public Sportsman[] Sportsmen => _sportsmen;
        public int SummaryScore {
            get {
                int result = 0;
                if (_sportsmen == null) return 0; 
                foreach (var sportsman in _sportsmen) {
                    result += sportsman.Place switch
                    {
                        1 => 5,
                        2 => 4,
                        3 => 3,
                        4 => 2,
                        5 => 1,
                        _ => 0
                    }; 
                }
                return result;
            }
        }
        public int TopPlace {
            get {
                if (_sportsmen == null || _count == 0) return int.MaxValue;
                return _sportsmen.Take(_count).Min(s => s.Place);
            }
        }

        // конструктор
        public Team(string name)
        {
            _name = name;
            _sportsmen = new Sportsman[6];
            _count = 0;
        }

        // методы
        public void Add(Sportsman sportsman)
        {
            if (_count < 6)
            {
                _sportsmen[_count] = sportsman;
                _count++;
            }
        }
        public void Add(Sportsman[] sportsmen)
        {
            foreach (var sportsman in sportsmen)
            {
                Add(sportsman);
            }
        }

        public void Print()
        {
            Console.WriteLine($"Команда: {_name}, Очки: {SummaryScore}, Лучшее место: {TopPlace}");
            foreach (var sportsman in _sportsmen)
            {
                sportsman.Print();
            }
        }

        public static void Sort(Team[] teams)
        {
            int n = teams.Length;
            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (teams[j].SummaryScore < teams[j + 1].SummaryScore ||
                        (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)) {
                        Team temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                    }
                }
            }
        }

    }
}