using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

namespace Lab_6
{
    public class Blue_1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }

            public string Name => _name;
            public string Surname => _surname;
            public int Votes => _votes;

            public int CountVotes(Response[] responses)
            {
                if (_name == null || _surname == null || responses == null)
                {
                    _votes = 0;
                    return 0;
                }
                int k = 0;
                for (int i = 0; i < responses.Length; i++)
                {
                    if (responses[i].Name == _name && responses[i].Surname == _surname)
                    {
                        k++;
                    }
                }
                _votes = k;
                return _votes;
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_votes}");
            }
        }
    }
}
