using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            // поля
            private string _name;
            private string _surname;
            private int _votes;

            // свойства (что разрешено делать с нашими полями)
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            // конструкторы (название как и у структуры)
            public Response(string name, string surname)            {
                
                _name = name;    //проинициализировали поля
                _surname = surname;
                _votes = 0;

            }

            //метод
            public int CountVotes(Response[] responses) //массив ответов (responses), где каждый элемент — это объект Response, содержащий имя и фамилию.
            {
                if (responses == null) { return 0; }
                int count = 0;
                foreach (var response in responses) //var автоматически определяет тип переменной
                {
                    if (response.Name == this.Name && response.Surname == this.Surname)
                    {
                        count++;
                    }                                 
                }
                this._votes = count;
                return count;
            }
        }
    }
}
