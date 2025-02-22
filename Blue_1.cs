using System;
using System.Linq;

namespace ConsoleApp1;

public class Blue_1
{
    public struct Response {

        // приватные поля
        private string _name;
        private string _surname;
        private int _votes;

        // публичные свойства

        public string Name => _name;
        public string Surname => _surname;
        public int Votes => _votes;

        // конструктор
        public Response(string name, string surname) {
            _name = name;
            _surname = surname;
            _votes = 0;
        }

        // методы
        // метод для подсчета голосов
        public int CountVotes(Response[] responses) {
            if (responses == null) return 0;
            int result = 0;
            foreach (var response in responses) {
                if (response.Name == _name && response.Surname == _surname) {
                    result++;
                };
            }
            this._votes = result;
            return result;
        }
        // метод для вывода информации о человеке
        public void Print() {
            Console.WriteLine($"{_name} {_surname}: {_votes}");
        }
    }
}