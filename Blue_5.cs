using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
