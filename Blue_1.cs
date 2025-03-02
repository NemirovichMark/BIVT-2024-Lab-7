using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            // поля
            private string name;
            private string surname;
            private int votes;

            // свойства
            public string Name => name;
            public string Surname => surname;
            public int Votes => votes;

            // Конструктор
            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.votes = 0; 
            }

            // Методы для подсчета голосов
            public int CountVotes(Response[] responses)
            {
                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == this.Name && response.Surname == this.Surname)
                    {
                        count++;
                    }
                }
                this.votes = count;
                return votes;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {Votes}");
            }
        }
    }
}