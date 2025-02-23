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

            private string name;
            private string surname;
            private int votes;
            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Votes: ");
                Console.WriteLine(votes);
            }
            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }

            public int Votes
            {
                get
                {
                    if (votes == null)
                        return 0;
                    return votes;
                }
            }

            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.votes = 0;
            }

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
                return count;
            }
        }
    }
}
