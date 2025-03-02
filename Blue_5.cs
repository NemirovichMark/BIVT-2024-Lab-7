using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_5
    {
        public struct Sportsman
        {
            // поля
            private string _name;
            private string _surname;
            private int _place;

            // свойства
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Place { get { return _place; } }

            // конструктор
            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            // остальные методы
            public void SetPlace(int place)
            {
                _place = place;
            }
            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Place}");
            }
        }
        // другая структура
        public struct Team
        {
            // поля
            private string _name;
            private Sportsman[] _sportsmen;

            private int _count;

            // свойства
            public string Name { get { return _name; } }
            public Sportsman[] Sportsmen {  get { return _sportsmen; } }
            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int sum = 0;
                    for (int i = 0; i < _sportsmen.Length; i++)
                    {
                        if (_sportsmen[i].Place == 1) sum += 5;
                        if (_sportsmen[i].Place == 2) sum += 4;
                        if (_sportsmen[i].Place == 3) sum += 3;
                        if (_sportsmen[i].Place == 4) sum += 2;
                        if (_sportsmen[i].Place == 5) sum += 1;
                    }
                    return sum;
                }
            }
            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;
                    int winner = 18;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place < winner) winner = _sportsmen[i].Place;
                    }
                    return winner;
                }
            }

            // конструктор
            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];

                _count = 0;
            }
            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _count >= 6) return;
                if (_count < 6)
                {
                    _sportsmen[_count++] = sportsman;
                }
            }
            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || _count >= 6) return;
                for (int i = 0; i < _sportsmen.Length; i++)
                {
                    if (_count >= 6) return;
                    if (_count < 6)
                    {
                        _sportsmen[_count++] = sportsmen[i];
                    }
                }
            }
            public static void Sort(Team[] teams)
            {
                for (int i = 0; i < teams.Length; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore ||
                            teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                        {
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
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
