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

            private string _name;
            private string _surname;
            private int _votes;


            public string Name { get { return _name; } }
            public string Surname => _surname;
            public int Votes => _votes;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }


            public int CountVotes(Response[] response)
            {
                int count = 0;
                foreach (var item in response)
                {
                    if (item.Name == this.Name && item.Surname == this.Surname)
                    {
                        count++;
                    }
                }

                _votes = count;
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - {Votes}");
            }
        }
    }
}
