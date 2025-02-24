using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_1
    {

        public struct Response
        {

            private string _name;
            private string _surname;
            private int _counter;


            public string Name { get { return _name; } }
            public string Surname => _surname;
            public int Counter => _counter;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _counter = 0;
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

                _counter = count;
                return count;
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} - {Counter}");
            }
        }
    }
}
