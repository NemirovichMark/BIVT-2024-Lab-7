using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            // поля ↓
            private string _name;
            private string _surname;
            private int _votes;

            // конструктор ↓
            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            // свойства ↓
            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            // методы ↓
            public int CountVotes(Response[] responses)
            {
                if (responses == null) { return 0; }

                _votes = 0;
                foreach (Response response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                    {
                        _votes++;
                    }
                }
                return _votes;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_votes}");
            }
        }
    }
}